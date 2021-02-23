using Emgu.CV;
using Emgu.CV.Structure;
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

namespace WpfBrowserApp1
{
    /// <summary>
    /// 
    /// 没有摄像头还没测试  但是RTSP播放好像不行
    /// 
    /// EmguCV    nuget需要安装这个包
    /// 安装完会有
    /// Emgu.CV.UI
    /// Emgu.CV.UI.GL
    /// Emgu.CV.World
    /// </summary>
    public partial class CameraWindow : Window
    {
        public CameraWindow()
        {
            InitializeComponent();
        }

        #region CV相关
        //emguCV捕捉视频信息的类
        Capture capture;
        //RTSP视频流地址
        string RTSPStream = "rtmp://58.200.131.2:1935/livetv/hunantv";

        private Bgr f = new Bgr(System.Drawing.Color.Red);
        //================初始化capture，用于打开按钮调用=======================
        public void InitCamera()
        {
            //将capture实例化，没有任何参数的实例化将会读取本地摄像头
            capture = new Capture();
            //捕捉图片时调用的事件
            capture.ImageGrabbed += Capture_ImageGrabbed;
        }
        /// <summary>
        /// 捕获图像的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Capture_ImageGrabbed(object sender, System.EventArgs e)
        {
            Mat frame = new Mat();
            capture.Retrieve(frame, 0);
            img.Image = frame;
        }
        #endregion

        #region 控件事件
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            InitCamera();
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (capture != null)
            {
                if ((string)Start.Content == "停止")
                {
                    //stop the capture
                    Start.Content = "开始";
                    capture.Pause();
                }
                else
                {
                    //start the capture
                    Start.Content = "停止";
                    capture.Start();
                }
            }
        }
        private void RTSP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //通过地址获取捕捉文件
                capture = new Capture(RTSPStream);
                //捕捉
                capture.ImageGrabbed += Capture_ImageGrabbed;
            }
            catch
            {
            }
        }
        #endregion
    }
}
