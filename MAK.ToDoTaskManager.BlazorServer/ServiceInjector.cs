using System;
using System.Linq;

using AppConfigSettings;

using Constants;

using Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Services;

namespace MAK.ToDoTaskManager.BlazorServer
{
    public static class ServiceInjector
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.InjectAppSettings<AppSettings>(configuration: configuration, configurationSection: AppSettingsData.App_Settings);

            var serviceList = typeof(Startup).Assembly.ExportedTypes
            .Where(service => typeof(IService).IsAssignableFrom(service) && !service.IsInterface && !service.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IService>().ToList();

            serviceList.ForEach(service => service.AddServices(services, configuration));

            return services;
        }
    }
}
