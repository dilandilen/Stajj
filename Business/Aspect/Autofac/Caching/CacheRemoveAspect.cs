using System;
using System.Collections.Generic;
using System.Text;
using Business.CrossCuttingConcerns.Caching;
using Business.Utilities.Intercepter;
using Business.Utilities.IoC;
using Castle.DynamicProxy;

using Microsoft.Extensions.DependencyInjection;

namespace Business.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodIntercepton
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
