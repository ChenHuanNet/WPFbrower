using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace WpfCoreApp1.Aop
{
    public class FuncAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"你正在调用方法 {invocation.Method.Name}  参数是 {string.Join(',', invocation.Arguments)}... ");
            //在被拦截的方法执行完毕后 继续执行           
            invocation.Proceed();
            Console.WriteLine($"方法执行完毕，返回结果：{invocation.ReturnValue}");
        }
    }
}
