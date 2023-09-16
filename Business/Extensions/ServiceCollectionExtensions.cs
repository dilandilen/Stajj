using System;
using System.Collections.Generic;
using System.Text;
using Business.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services,
            IBusinessModule[] modules)
        {
            foreach (var module in modules)
            {
               module.Load(services); 
            }

            return ServiceTool.Create(services);
        }
    }
}
