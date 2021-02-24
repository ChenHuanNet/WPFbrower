using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfCoreApp1.ViewModel;

namespace WpfCoreApp1
{
    /// <summary>
    /// MvvmWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MvvmWindow : Window
    {
        public MvvmWindowViewModel _MvvmWindowViewModel { get; set; }
        public MvvmWindow()
        {
            InitializeComponent();

        }


        public void Init()
        {
            _MvvmWindowViewModel.Init();
            //这里DataContext不能写在xaml上面。 写在xaml上面会重新new 一个对象就不是容器创建的对象了，就没办法注入了
            this.DataContext = _MvvmWindowViewModel;

            _MvvmWindowViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler((o, t) =>
            {
                //值改变了之后重新绑定到UI
                this.DataContext = null;
                this.DataContext = _MvvmWindowViewModel;
            });
        }
    }
}
