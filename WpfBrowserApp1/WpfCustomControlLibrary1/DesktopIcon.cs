using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCustomControlLibrary1
{
    public class DesktopIcon : Button
    {
        static DesktopIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DesktopIcon), new FrameworkPropertyMetadata(typeof(DesktopIcon)));
        }


    }
}
