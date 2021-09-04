using Domain;

using Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Repositories;

namespace Services
{
    public class RepositoryInjector : IService
    {
        public IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddScoped<IToDoTaskCategoryRepository, ToDoTaskCategoryRepository>();
            services.AddScoped<IRepository<ToDoTaskCategory, int>, Repository<ToDoTaskCategory, int>>();

            services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
            services.AddScoped<IRepository<ToDoTask, int>, Repository<ToDoTask, int>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
