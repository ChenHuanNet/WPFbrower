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
using WpfCoreApp1.Sevices;

namespace WpfCoreApp1
{
    /// <summary>
    /// ManageDemo.xaml 的交互逻辑
    /// </summary>
    public partial class ManageDemo : Window
    {

        ManageSevice manageSevice;

        public ManageDemo()
        {
            InitializeComponent();

            manageSevice = new ManageSevice();
            Init();
        }

        void Init()
        {
            var datas = manageSevice.GetManageData();
            this.dataGrid.ItemsSource = datas;
        }

    }
}
