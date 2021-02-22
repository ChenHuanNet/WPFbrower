using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCoreCustomControlLibrary1
{
    /// <summary>
    /// 拖拽事件  还没用有点问题
    /// </summary>
    public class MyDragEvent
    {
        public static Point MouseLeftButtonDown(object sender, MouseButtonEventArgs e, Canvas canvas)
        {
            Control tmp = (Control)sender;
            Point pos = e.GetPosition(canvas);//鼠标相对于canvas的位置
            tmp.CaptureMouse();
            tmp.Cursor = Cursors.Hand;
            return pos;
        }

        public static void MouseLeftButtonUp(object sender, MouseButtonEventArgs e, Canvas canvas, double maxWidth, double maxHeight)
        {
            Control tmp = (Control)sender;

            double dx = e.GetPosition(canvas).X;
            double dy = e.GetPosition(canvas).Y;

            int fx = (int)((dx - 10) / 100);
            if (fx * 100 > maxWidth - 100)
            {
                fx = (int)((maxWidth - 10) / 100) - 1;
            }
            if (fx < 0)
            {
                fx = 0;
            }
            int fy = (int)(dy - 10) / 120;
            if (fy * 120 > maxHeight - 120)
            {
                fy = (int)((maxHeight - 10) / 120);
            }
            if (fy <= 0)
            {
                fy = 0;
            }

            dx = fx * 100 + 20;
            dy = fy * 120 + 20;

            while (true)
            {
                bool isFind = false;
                UIElementCollection children = canvas.Children;
                foreach (UIElement child in children)
                {
                    Control c = (Control)child;
                    if (c.Margin.Top == dy && c.Margin.Left == dx)
                    {
                        isFind = true;

                        dy = dy + 120;
                        if (dy > maxHeight - 120)
                        {
                            dy = 20;
                            dx = dx + 100;
                        }

                        break;
                    }
                }

                if (!isFind)
                {
                    break;
                }
            }




            tmp.Margin = new Thickness(dx, dy, 0, 0);
            tmp.ReleaseMouseCapture();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="canvas"></param>
        /// <param name="pos">前一时刻鼠标位置所在的坐标</param>
        public static void MouseMove(object sender, MouseEventArgs e, Canvas canvas, ref Point p)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Control tmp = (Control)sender;
                double dx = e.GetPosition(canvas).X;
                double dy = e.GetPosition(canvas).Y;

                tmp.Margin = new Thickness(dx, dy, 0, 0);
                p = e.GetPosition(canvas);
            }
        }
    }
}
