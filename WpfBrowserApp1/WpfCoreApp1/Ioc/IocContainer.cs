using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfCoreApp1.Ioc
{
    public class IocContainer
    {
        static IContainer _container;


        public static object GetContainer(Type t)
        {
            return _container.Resolve(t);
        }


        public static void SetContainer(IContainer container)
        {
            _container = container;
        }


        public static T GetContainer<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
