using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tomato.MVVM
{
    /// <summary>
    /// 可绑定对象的基类
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 属性更改时引发
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="property">属性</param>
        /// <param name="value">值</param>
        /// <param name="propertyName">属性名称</param>
        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if(!object.Equals(property, value))
            {
                property = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
