using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCustomControlLibrary1
{
    public class IconInputbox : TextBox
    {
        static IconInputbox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconInputbox), new FrameworkPropertyMetadata(typeof(IconInputbox)));


        }

        public override void EndInit()
        {
            base.EndInit();

            if (this.Width.ToString().ToUpper() != "NAN")
            {
                this.InputWidth = this.Width - 24;
            }
        }


        /// <summary>
        /// 图标 不是自带的 必须用RelativeSource绑定 {Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type local:IconButton}},Path=Icon}
        /// </summary>
        public string Icon { get; set; }

        public double InputWidth { get; set; }

        public int MaxInputWidth { get; set; } = 300;

        public int MinInputHeight { get; set; } = 16;

    }
}
