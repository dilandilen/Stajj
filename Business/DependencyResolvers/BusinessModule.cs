using System;
using System.Collections.Generic;
using System.Text;
using Business.CrossCuttingConcerns.Caching;
using Business.CrossCuttingConcerns.Caching.Microsoft;
using Business.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public class BusinessModule:IBusinessModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
           services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
