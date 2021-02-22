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
using System.Windows.Resources;
using System.Windows.Shapes;
using WpfBrowserApp1.Sevices;
using WpfUtils;

namespace WpfBrowserApp1
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
