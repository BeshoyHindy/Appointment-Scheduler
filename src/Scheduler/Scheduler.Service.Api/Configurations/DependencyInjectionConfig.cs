using Microsoft.Extensions.DependencyInjection;
using Scheduler.Infra.CrossCutting.IoC;
using System;

namespace Scheduler.Service.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootstrapper.RegisterServices(services);
        }
    }

}
