using System.Collections.Generic;

using Domain;

using DTOs;

using HttpServices;

using Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PageFeatures;

namespace Services
{
    public static class Injector
    {
        public static IServiceCollection InjectCore(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddScoped<ITaskService<ToDoTaskDto>, ToDoTaskService>();

            services.AddHttpClient<IHttpToDoTaskCategoryService, HttpToDoTaskCategoryService>();
            services.AddScoped<ToDoTaskCategory>();
            services.AddScoped<List<ToDoTaskCategory>>();

            services.AddHttpClient<IHttpToDoTaskService, HttpToDoTaskService>();
            services.AddScoped<ToDoTaskDto>();
            services.AddScoped<List<ToDoTaskDto>>();
            
            services.AddHttpClient<HttpImageUploaderService>();
            services.AddHttpClient<HttpResourceService>();

            services.AddScoped<PagerData>();
            services.AddScoped<List<PagerData>>();
            services.AddScoped<PagingEntity>();
            services.AddScoped<List<PagingEntity>>();

            return services;
        }
    }
}
