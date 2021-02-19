using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfCustomControlLibrary1
{
    public class ControlAttachProperty
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


        #region 图标
        public static string GetIcon(DependencyObject obj)
        {
            return (string)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, string value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(string), typeof(ControlAttachProperty), new PropertyMetadata(null));

        #endregion
    }
}
