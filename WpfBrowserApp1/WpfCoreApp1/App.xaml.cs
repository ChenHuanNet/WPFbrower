using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfCoreApp1.Aop;
using WpfCoreApp1.Ioc;
using WpfCoreApp1.Mapper;
using WpfCoreApp1.Sevices;

namespace WpfCoreApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// autofac
        /// </summary>
        //private IContainer container;


        /// <summary>
        /// Microsoft.Extensions.DependencyInjection
        /// </summary>
        ServiceProvider _serviceProvider;
        public App()
        {
            //var serviceCollection = new ServiceCollection();
            //ConfigureServices(serviceCollection);

            //_serviceProvider = serviceCollection.BuildServiceProvider();


            //构造函数中添加如下代码
            var builder = new ContainerBuilder();
            AutofacConfigureSevices(builder);

            var container = builder.Build();
            IocContainer.SetContainer(container);
        }

        /// <summary>
        /// 这个在初始化的时候 是无法使用的，必须等初始化完成之后才能被注入
        /// </summary>
        /// <param name="builder"></param>
        private void AutofacConfigureSevices(ContainerBuilder builder)
        {
            //builder.RegisterType<FirstModel>().Named<IService>("First");
            //builder.RegisterType<SecondModel>().Named<IService>("Second");
            //builder.RegisterType<SecondModel>().Named<ISecondService>("Second");
            //builder.RegisterType<ThirdModel>();
            //builder.RegisterInstance(this).As<Form>();

            //Aop拦截器也要注册 
            //然后再需要拦截的类后面加 .EnableInterfaceInterceptors().InterceptedBy(typeof(FuncAop)) 全局   或者类头部加属性[Intercept(typeof(FuncAop))]   
            builder.RegisterType<FuncAop>();
            //注入跟注册顺序没有关系，从内向外和从外向内都试过了。  属性注入必须 {get;set;}   PropertiesAutowired() 是根据反射赋值进去的
            //.EnableInterfaceInterceptors().InterceptedBy 启动AOP拦截
            builder.RegisterType<TempDataMapper>().As<ITempDataMapper>().PropertiesAutowired().EnableInterfaceInterceptors().InterceptedBy(typeof(FuncAop));
            builder.RegisterType<DesktopSevice>().PropertiesAutowired();
            builder.RegisterType<ManageSevice>().PropertiesAutowired();
            builder.RegisterType<MainWindow>().PropertiesAutowired();
            builder.RegisterType<ManageSevice>().PropertiesAutowired();
            builder.RegisterType<ManageDemo>().PropertiesAutowired();
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
        /// 将启动方式由StartupUri变成了事件Startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //autofac 形式
            var main = IocContainer.GetContainer<MainWindow>();
            main.Show();
            main.Init();//因为在 构造函数没执行完的时候，是没办法注入的。所以提成公用方法单独执行


            //微软的IOC包  Microsoft.Extensions.DependencyInjection
            //var main = _serviceProvider.GetRequiredService<MainWindow>();
            // main.Show();
        }
    }
}
