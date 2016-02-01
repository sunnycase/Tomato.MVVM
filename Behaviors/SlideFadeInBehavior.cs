using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Tomato.MVVM.Wpf.Behaviors
{
    public class SlideFadeInBehavior : Behavior<UIElement>
    {
        private const double SlideDistance = 40.0;
        public static readonly DependencyProperty DurationProperty = DependencyProperty.Register("Duration", typeof(Duration), typeof(SlideFadeInBehavior), new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(750.0))));
        private static readonly DependencyProperty BeginTimeProperty = DependencyProperty.Register("BeginTime", typeof(TimeSpan), typeof(SlideFadeInBehavior), new PropertyMetadata(TimeSpan.FromMilliseconds(0.0)));
        public Duration Duration
        {
            get
            {
                return (Duration)base.GetValue(SlideFadeInBehavior.DurationProperty);
            }
            set
            {
                base.SetValue(SlideFadeInBehavior.DurationProperty, value);
            }
        }
        public TimeSpan BeginTime
        {
            get
            {
                return (TimeSpan)base.GetValue(SlideFadeInBehavior.BeginTimeProperty);
            }
            set
            {
                base.SetValue(SlideFadeInBehavior.BeginTimeProperty, value);
            }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            base.AssociatedObject.Opacity = 0.0;
        }
        public static Storyboard DoSlideFadeIn(FrameworkElement container)
        {
            List<SlideFadeInBehavior> list = new List<SlideFadeInBehavior>();
            IEnumerable<UIElement> logicalChildren = container.GetLogicalChildren<UIElement>();
            foreach (UIElement current in logicalChildren)
            {
                list.AddRange(
                    from b in Interaction.GetBehaviors(current)
                    where b is SlideFadeInBehavior
                    select b as SlideFadeInBehavior);
            }
            IEnumerable<Timeline> enumerable = list.SelectMany((SlideFadeInBehavior s) => s.CreateAnimations());
            Storyboard storyboard = new Storyboard();
            foreach (Timeline current2 in enumerable)
            {
                storyboard.Children.Add(current2);
            }
            storyboard.Begin(container);
            return storyboard;
        }
        private IEnumerable<Timeline> CreateAnimations()
        {
            TranslateTransform renderTransform = new TranslateTransform
            {
                X = -40.0,
                Y = 0.0
            };
            base.AssociatedObject.RenderTransform = renderTransform;
            DoubleAnimation doubleAnimation = new DoubleAnimation
            {
                From = new double?(0.0),
                To = new double?(1.0),
                Duration = this.Duration,
                BeginTime = new TimeSpan?(this.BeginTime)
            };
            DoubleAnimation doubleAnimation2 = new DoubleAnimation
            {
                To = new double?(0.0),
                Duration = this.Duration,
                BeginTime = new TimeSpan?(this.BeginTime)
            };
            doubleAnimation2.EasingFunction = new CubicEase
            {
                EasingMode = EasingMode.EaseOut
            };
            Storyboard.SetTarget(doubleAnimation, base.AssociatedObject);
            Storyboard.SetTarget(doubleAnimation2, base.AssociatedObject);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(UIElement.OpacityProperty));
            Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)", new object[0]));
            return new List<Timeline>
            {
                doubleAnimation,
                doubleAnimation2
            };
        }
    }
}
