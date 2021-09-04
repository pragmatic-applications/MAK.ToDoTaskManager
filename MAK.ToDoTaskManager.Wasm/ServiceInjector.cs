using System;
using System.Linq;

using Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MAK.ToDoTaskManager.Wasm
{
    public static class ServiceInjector
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services, IConfiguration configuration = null)
        {
            var serviceList = typeof(Program).Assembly.ExportedTypes
            .Where(service => typeof(IService).IsAssignableFrom(service) && !service.IsInterface && !service.IsAbstract)
            .Select(Activator.CreateInstance).Cast<IService>().ToList();

            serviceList.ForEach(service => service.AddServices(services, configuration));

            return services;
        }
    }
}
