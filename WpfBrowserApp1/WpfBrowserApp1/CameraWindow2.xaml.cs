using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// 没有摄像头还没测试
    /// 
    /// NUGET 安装以下包   
    /// 
    ///AForge.dll
    ///AForge.Controls.dll
    ///AForge.Imaging.dll
    ///AForge.Video.dll
    ///AForge.Video.DirectShow.dll
    /// </summary>
    public partial class CameraWindow2 : Window
    {
        public CameraWindow2()
        {
            InitializeComponent();
        }

        FilterInfoCollection a;//全局变量摄像头数据
        private void lj_Click(object sender, RoutedEventArgs e)
        {
            VideoCaptureDevice vcd = new VideoCaptureDevice(a[name1.SelectedIndex].MonikerString);
            vcd.DesiredFrameSize = new System.Drawing.Size(320, 240);
            vcd.DesiredFrameRate = 1;

            sourcePlayer0.VideoSource = vcd;
            sourcePlayer0.Start();
        }

        private void jc_Click(object sender, RoutedEventArgs e)
        {
            name1.Items.Clear();
            FilterInfoCollection fics;
            fics = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            a = fics;
            foreach (FilterInfo fic in fics)
            {

                name1.Items.Add(fic.Name);
                //可以做出处理
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sourcePlayer0.IsRunning)
                {
                    BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                    sourcePlayer0.GetCurrentVideoFrame().GetHbitmap(),
                                    IntPtr.Zero,
                                     Int32Rect.Empty,
                                    BitmapSizeOptions.FromEmptyOptions());
                    PngBitmapEncoder pbe = new PngBitmapEncoder();
                    pbe.Frames.Add(BitmapFrame.Create(bs));
                    string t = DateTime.Now.ToLongTimeString().ToString();

                    t = t.Replace("-", "");
                    t = t.Replace(":", "");
                    string jpgName = GetImagePath() + "\\" + t + ".jpg";
                    if (File.Exists(jpgName))
                    {
                        File.Delete(jpgName);
                    }
                    using (Stream stream = File.Create(jpgName))
                    {
                        pbe.Save(stream);
                    }
                    //拍照
                    if (sourcePlayer0 != null && sourcePlayer0.IsRunning)
                    {
                        MessageBox.Show("照片储存地址：" + jpgName);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常：" + ex.Message);
            }
        }
        private string GetImagePath()
        {

            string t = DateTime.Now.ToShortDateString().ToString();
            string ImgPath = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
                         + System.IO.Path.DirectorySeparatorChar.ToString() + "PersonImg";
            if (!Directory.Exists(ImgPath))
            {
                Directory.CreateDirectory(ImgPath);
            }

            return ImgPath;
        }
    }
}
