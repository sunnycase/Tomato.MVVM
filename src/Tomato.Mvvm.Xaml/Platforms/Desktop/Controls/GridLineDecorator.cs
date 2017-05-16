﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Tomato.Mvvm.Controls
{
    [ContentProperty("Target")]
    public class GridLineDecorator : FrameworkElement
    {
        private ListView _target;
        private DrawingVisual _gridLinesVisual = new DrawingVisual();
        private GridViewHeaderRowPresenter _headerRowPresenter = null;

        public GridLineDecorator()
        {
            this.AddVisualChild(_gridLinesVisual);
            this.AddHandler(ScrollViewer.ScrollChangedEvent, new RoutedEventHandler(OnScrollChanged));
        }

        #region GridLineBrush

        /// <summary>
        /// GridLineBrush Dependency Property
        /// </summary>
        public static readonly DependencyProperty GridLineBrushProperty =
            DependencyProperty.Register("GridLineBrush", typeof(Brush), typeof(GridLineDecorator),
                new FrameworkPropertyMetadata(Brushes.LightGray,
                    new PropertyChangedCallback(OnGridLineBrushChanged)));

        /// <summary>
        /// Gets or sets the GridLineBrush property.  This dependency property 
        /// indicates ....
        /// </summary>
        public Brush GridLineBrush
        {
            get { return (Brush)GetValue(GridLineBrushProperty); }
            set { SetValue(GridLineBrushProperty, value); }
        }

        /// <summary>
        /// Handles changes to the GridLineBrush property.
        /// </summary>
        private static void OnGridLineBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((GridLineDecorator)d).OnGridLineBrushChanged(e);
        }

        /// <summary>
        /// Provides derived classes an opportunity to handle changes to the GridLineBrush property.
        /// </summary>
        protected virtual void OnGridLineBrushChanged(DependencyPropertyChangedEventArgs e)
        {
            DrawGridLines();
        }

        #endregion

        #region Target

        public ListView Target
        {
            get { return _target; }
            set
            {
                if (_target != value)
                {
                    if (_target != null) Detach();
                    RemoveVisualChild(_target);
                    RemoveLogicalChild(_target);

                    _target = value;

                    AddVisualChild(_target);
                    AddLogicalChild(_target);
                    if (_target != null) Attach();

                    InvalidateMeasure();
                }
            }
        }

        private void GetGridViewHeaderPresenter()
        {
            if (Target == null)
            {
                _headerRowPresenter = null;
                return;
            }
            _headerRowPresenter = Target.FindFirstVisualChildOfType<GridViewHeaderRowPresenter>();
        }

        #endregion

        #region DrawGridLines

        private void DrawGridLines()
        {
            if (Target == null) return;
            if (_headerRowPresenter == null) return;

            var itemCount = Target.Items.Count;
            if (itemCount == 0) return;

            var gridView = Target.View as GridView;
            if (gridView == null) return;

            // 获取drawingContext
            var drawingContext = _gridLinesVisual.RenderOpen();
            var startPoint = new Point(0, 0);
            var totalHeight = 0.0;

            // 为了对齐到像素的计算参数，否则就会看到有些线是模糊的
            var dpiFactor = this.GetDpiFactor();
            var pen = new Pen(this.GridLineBrush, 1 * dpiFactor);
            var halfPenWidth = pen.Thickness / 2;
            var guidelines = new GuidelineSet();

            // 画横线
            for (int i = 0; i < itemCount; i++)
            {
                var item = Target.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;
                if (item != null)
                {
                    var renderSize = item.RenderSize;
                    var offset = item.TranslatePoint(startPoint, this);

                    var hLineX1 = offset.X;
                    var hLineX2 = offset.X + renderSize.Width;
                    var hLineY = offset.Y + renderSize.Height;

                    // 加入参考线，对齐到像素
                    guidelines.GuidelinesY.Add(hLineY + halfPenWidth);
                    drawingContext.PushGuidelineSet(guidelines);
                    drawingContext.DrawLine(pen, new Point(hLineX1, hLineY), new Point(hLineX2, hLineY));
                    drawingContext.Pop();

                    // 计算竖线总高度
                    totalHeight += renderSize.Height;
                }
            }

            // 画竖线
            var columns = gridView.Columns;
            var headerOffset = _headerRowPresenter.TranslatePoint(startPoint, this);
            var headerSize = _headerRowPresenter.RenderSize;

            var vLineX = headerOffset.X;
            var vLineY1 = headerOffset.Y + headerSize.Height;

            foreach (var column in columns)
            {
                var columnWidth = column.GetColumnWidth();
                vLineX += columnWidth;

                // 加入参考线，对齐到像素
                guidelines.GuidelinesX.Add(vLineX + halfPenWidth);
                drawingContext.PushGuidelineSet(guidelines);
                drawingContext.DrawLine(pen, new Point(vLineX, vLineY1), new Point(vLineX, vLineY1 + totalHeight));
                drawingContext.Pop();
            }

            drawingContext.Close();
        }

        #endregion

        #region Overrides to show Target and grid lines

        protected override int VisualChildrenCount
        {
            get { return Target == null ? 1 : 2; }
        }

        protected override System.Collections.IEnumerator LogicalChildren
        {
            get { yield return Target; }
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index == 0) return _target;
            if (index == 1) return _gridLinesVisual;
            throw new IndexOutOfRangeException(string.Format("Index of visual child '{0}' is out of range", index));
        }

        protected override Size MeasureOverride(Size constraint)
        {
            UIElement child = this.Target;
            if (child != null)
            {
                child.Measure(constraint);
                return child.DesiredSize;
            }
            return default(Size);
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            UIElement child = this.Target;
            if (child != null)
                child.Arrange(new Rect(arrangeSize));
            return arrangeSize;
        }

        #endregion

        #region Handle Events

        private void Attach()
        {
            _target.Loaded += OnTargetLoaded;
            _target.Unloaded += OnTargetUnloaded;
        }

        private void Detach()
        {
            _target.Loaded -= OnTargetLoaded;
            _target.Unloaded -= OnTargetUnloaded;
        }

        private void OnTargetLoaded(object sender, RoutedEventArgs e)
        {
            if (_headerRowPresenter == null)
                GetGridViewHeaderPresenter();
            DrawGridLines();
        }

        private void OnTargetUnloaded(object sender, RoutedEventArgs e)
        {
            DrawGridLines();
        }

        private void OnScrollChanged(object sender, RoutedEventArgs e)
        {
            DrawGridLines();
        }

        #endregion
    }
}
