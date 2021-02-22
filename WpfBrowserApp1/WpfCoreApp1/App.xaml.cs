using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfCoreApp1.Mapper;
using WpfCoreApp1.Sevices;

namespace WpfCoreApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private IContainer container;



        ServiceProvider _serviceProvider;
        public App()
        {
            //var serviceCollection = new ServiceCollection();
            //ConfigureServices(serviceCollection);

            //_serviceProvider = serviceCollection.BuildServiceProvider();


            //构造函数中添加如下代码
            var builder = new ContainerBuilder();
            AutofacConfigureSevices(builder);

            container = builder.Build();
        }

        private void AutofacConfigureSevices(ContainerBuilder builder)
        {
            //builder.RegisterType<FirstModel>().Named<IService>("First");
            //builder.RegisterType<SecondModel>().Named<IService>("Second");
            //builder.RegisterType<SecondModel>().Named<ISecondService>("Second");
            //builder.RegisterType<ThirdModel>();
            //builder.RegisterInstance(this).As<Form>();

            builder.RegisterType<DesktopSevice>();
            builder.RegisterType<ManageSevice>();
            builder.RegisterType<TempDataMapper>().As<ITempDataMapper>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //这个是利用 Microsoft.Extensions.DependencyInjection 微软.net core自带的包 用构造函数注入的 需要去nuget添加 
            //注入顺序没有关系
            services.AddTransient<DesktopSevice>();
            services.AddTransient<ManageSevice>();
            services.AddTransient<ITempDataMapper, TempDataMapper>();
            services.AddSingleton<MainWindow>();
        }

        /// <summary>
        /// 将启动方式由Uri变成了事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
           //var main = _serviceProvider.GetRequiredService<MainWindow>();
           // main.Show();
        }
    }
}
