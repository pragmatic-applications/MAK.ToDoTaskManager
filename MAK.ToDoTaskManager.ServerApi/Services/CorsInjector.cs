using Constants;

using Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Services
{
    public class CorsInjector : IService
    {
        public IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddCors
            (
                corsOptions => corsOptions.AddPolicy
                (
                    ConstantUrl.CorsPolicyNane, corsPolicyBuilder => corsPolicyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders(HttpConstant.X_Pagination)
                )
            );

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact_Book_Server_Api", Version = "v1" }));

            return services;
        }
    }
}
