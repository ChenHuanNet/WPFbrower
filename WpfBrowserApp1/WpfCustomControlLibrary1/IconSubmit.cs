using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfCustomControlLibrary1
{
    public class IconSubmit : Button
    {
        static IconSubmit()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconSubmit), new FrameworkPropertyMetadata(typeof(IconSubmit)));
        }

        public override void EndInit()
        {
            base.EndInit();

            this.Background = Brushes.LightGray;
        }

        /// <summary>
        /// 图标 不是自带的 必须用RelativeSource绑定 {Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type local:IconButton}},Path=Icon}
        /// </summary>
        public string Icon { get; set; }



    }
}
