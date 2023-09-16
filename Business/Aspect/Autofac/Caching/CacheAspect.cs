using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Business.CrossCuttingConcerns.Caching;
using Business.Utilities.Intercepter;
using Business.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodIntercepton
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType?.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.Select(arg => arg?.ToString() ?? "<Null>").ToList();
            var key = $"{methodName}({string.Join(",", arguments)})";

            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
