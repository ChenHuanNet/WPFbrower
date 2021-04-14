
using System;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Media;

namespace WpfCoreApp1
{
    /// <summary>
    /// VideoEncrypt.xaml 的交互逻辑
    /// </summary>
    public partial class VideoEncrypt : Window
    {

        byte[] tmp = new byte[1024];

        public VideoEncrypt()
        {
            InitializeComponent();
        }

        public void Init()
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Videos\mda-kfe0b1k93crdnbn7.mp4");
            tmp = File.ReadAllBytes(path);

            video.Source = new Uri(path);

            var videoDevices = MultimediaUtil.VideoInputNames;// 获取所有视频设备	 
            string videoName = videoDevices[0];// 选择第一个
        }


        private void start_Click(object sender, RoutedEventArgs e)
        {
            video.Play();
            pause.IsEnabled = true; resume.IsEnabled = false; stop.IsEnabled = true; start.IsEnabled = false;
        }
        private void stop_Click(object sender, RoutedEventArgs e)
        {
            video.Stop();

            start.IsEnabled = true; pause.IsEnabled = false; resume.IsEnabled = false; stop.IsEnabled = false;
        }
        private void resume_Click(object sender, RoutedEventArgs e)
        {
            video.Play();
            start.IsEnabled = false; pause.IsEnabled = true; resume.IsEnabled = true; stop.IsEnabled = true;
        }
        private void pause_Click(object sender, RoutedEventArgs e)
        {
            video.Pause();
            start.IsEnabled = false; pause.IsEnabled = false; resume.IsEnabled = true; stop.IsEnabled = false;
        }
    }
}
