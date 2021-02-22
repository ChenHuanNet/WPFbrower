using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCustomControlLibrary1
{
    public class IconButton : Button
    {
        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
        }

        /// <summary>
        /// 图标 不是自带的 必须用RelativeSource绑定 {Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type local:IconButton}},Path=Icon}
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 是否可以拖动 根据这个给他判断是否动态增加拖动事件
        /// </summary>
        public bool IsDrag { get; set; } = false;

    }
}
