using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCustomControlLibrary1
{
    /// <summary>
    /// 拖拽事件  还没用有点问题
    /// </summary>
    public class MyDragEvent
    {
        
        Canvas canvas;
        double maxWidth;
        double maxHeight;
        public MyDragEvent(Canvas canvas, double maxWidth, double maxHeight)
        {
            this.canvas = canvas;
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
        }

        Point pos = new Point();
        public void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Control tmp = (Control)sender;
            pos = e.GetPosition(this.canvas);
            tmp.CaptureMouse();
            tmp.Cursor = Cursors.Hand;
        }

        public void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Button tmp = (Button)sender;

            double dx = e.GetPosition(this.canvas).X;
            double dy = e.GetPosition(this.canvas).Y;

            int fx = (int)((dx - 10) / 100);
            if (fx * 100 > this.maxWidth - 100)
            {
                fx = (int)((this.maxWidth - 10) / 100) - 1;
            }
            if (fx < 0)
            {
                fx = 0;
            }
            int fy = (int)(dy - 10) / 120;
            if (fy * 120 > this.maxHeight - 120)
            {
                fy = (int)((this.maxHeight - 10) / 120);
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
                UIElementCollection children = this.canvas.Children;
                foreach (UIElement child in children)
                {
                    Control c = (Control)child;
                    if (c.Margin.Top == dy && c.Margin.Left == dx)
                    {
                        isFind = true;

                        dy = dy + 120;
                        if (dy > this.maxHeight - 120)
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
        /// 一个图标宽80高100，间距20
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Control tmp = (Control)sender;
                double dx = e.GetPosition(this.canvas).X;
                double dy = e.GetPosition(this.canvas).Y;


                tmp.Margin = new Thickness(dx, dy, 0, 0);
                pos = e.GetPosition(this.canvas);
            }
        }
    }
}
