using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfCustomControlLibrary1
{
    /// <summary>
    /// 这个是附加属性   这个是所有控件，包含子控件都能使用同一个属性值，但是自定义控件  他是静态的无法使用RelativeSource进行绑定
    /// </summary>
    public class ControlAttachProperty: DependencyObject
    {
        #region 图标

        public static string GetIconImage(DependencyObject obj)
        {
            return (string)obj.GetValue(IconImageProperty);
        }

        public static void SetIconImage(DependencyObject obj, string value)
        {
            obj.SetValue(IconImageProperty, value);
        }

        public static readonly DependencyProperty IconImageProperty =
            DependencyProperty.RegisterAttached("IconImage", typeof(string), typeof(ControlAttachProperty), new PropertyMetadata(null));

        #endregion

    }
}
