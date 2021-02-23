using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfCustomControlLibrary1;

namespace WpfBrowserApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        Point pos = new Point();

        DesktopSevice desktopSevice;

        public MainWindow()
        {
            InitializeComponent();
            desktopSevice = new DesktopSevice();
            Init();
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
                    c.AddHandler(Button.MouseLeftButtonUpEvent, new MouseButtonEventHandler((o, e) => { MyDragEvent.MouseLeftButtonUp(o, e, this.canvas, this.ActualWidth, this.ActualHeight); }), true);//注册事件
                    c.AddHandler(Button.MouseMoveEvent, new MouseEventHandler((o, e) => { MyDragEvent.MouseMove(o, e, this.canvas, ref pos); }), true);//注册事件 
                }
            }

        }
    }
}
