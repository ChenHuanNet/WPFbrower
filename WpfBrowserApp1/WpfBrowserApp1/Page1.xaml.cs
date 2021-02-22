using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Xml;
using WpfBrowserApp1.Sevices;
using WpfCustomControlLibrary1;
using WpfUtils;

namespace WpfBrowserApp1
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        Point pos = new Point();

        DesktopSevice desktopSevice;

        public Page1()
        {
            InitializeComponent();

            desktopSevice = new DesktopSevice();
            Init();


            //button5.AddHandler(Button.MouseLeftButtonDownEvent, new MouseButtonEventHandler(canvas_MouseLeftButtonDown), true);//注册事件
            //button5.AddHandler(Button.MouseLeftButtonUpEvent, new MouseButtonEventHandler(canvas_MouseLeftButtonUp), true);//注册事件
            //button5.AddHandler(Button.MouseMoveEvent, new MouseEventHandler(canvas_MouseMove), true);//注册事件   
        }


        void Init()
        {
            #region 启动时串口最大化显示
            Rect rc = SystemParameters.WorkArea; //获取工作区大小
            this.Width = rc.Width;
            this.Height = rc.Height;
            #endregion

            desktopSevice.AutoCreateDesktopButton(this.canvas, this.Width, this.Height);


            foreach (var item in this.canvas.Children)
            {
                Control c = (Control)item;
                if (c is IconButton && (c as IconButton).IsDrag)
                {
                    c.AddHandler(Button.MouseLeftButtonDownEvent, new MouseButtonEventHandler((o, e) => { pos = MyDragEvent.MouseLeftButtonDown(o, e, this.canvas); }), true);//注册事件
                    c.AddHandler(Button.MouseLeftButtonUpEvent, new MouseButtonEventHandler((o, e) => { MyDragEvent.MouseLeftButtonUp(o, e, this.canvas, this.WindowWidth, this.WindowHeight); }), true);//注册事件
                    c.AddHandler(Button.MouseMoveEvent, new MouseEventHandler((o, e) => { MyDragEvent.MouseMove(o, e, this.canvas, ref pos); }), true);//注册事件 
                }
            }

        }

        #region 没用了

        ControlsTest controlsTest;


        private void button1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ControlsTest test = new ControlsTest();
            test.ShowDialog();

        }

        private void button2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ////Point p = e.GetPosition(this.canvas);
            ////MessageBox.Show($"{p.X},{p.Y}");
            var keys = this.Resources.Keys;

            //MessageBox.Show(this.button5.Tag + "");
        }



        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button tmp = (Button)sender;
            pos = e.GetPosition(this.canvas);
            tmp.CaptureMouse();
            tmp.Cursor = Cursors.Hand;
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Button tmp = (Button)sender;

            double dx = e.GetPosition(this.canvas).X;
            double dy = e.GetPosition(this.canvas).Y;

            int fx = (int)((dx - 10) / 100);
            if (fx * 100 > this.WindowWidth - 100)
            {
                fx = (int)((this.WindowWidth - 10) / 100) - 1;
            }
            if (fx < 0)
            {
                fx = 0;
            }
            int fy = (int)(dy - 10) / 120;
            if (fy * 120 > this.WindowHeight - 120)
            {
                fy = (int)((this.WindowHeight - 10) / 120);
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
                        if (dy > this.WindowHeight - 120)
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
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Button tmp = (Button)sender;
                double dx = e.GetPosition(this.canvas).X;
                double dy = e.GetPosition(this.canvas).Y;


                tmp.Margin = new Thickness(dx, dy, 0, 0);
                pos = e.GetPosition(this.canvas);
            }
        }

        #endregion
    }
}
