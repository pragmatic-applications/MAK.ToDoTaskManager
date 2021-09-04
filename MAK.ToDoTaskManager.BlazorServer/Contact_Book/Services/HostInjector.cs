using Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public class HostInjector : IService
    {
        public IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration = null)
        {
            services.InjectCore();

            // MVC
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddServerSideBlazor();

            services.AddRouting(options => options.LowercaseUrls = true);

            // Razor Features
            services.Configure<RazorViewEngineOptions>(o =>
            {
                o.ViewLocationFormats.Add("~/Features/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("~/Features/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("~/Features/Shared/{0}" + RazorViewEngine.ViewExtension);

                //o.AreaViewLocationFormats.Clear();
                o.AreaViewLocationFormats.Add("~/Areas/{2}/Features/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.AreaViewLocationFormats.Add("~/Areas/{2}/Features/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
                o.AreaViewLocationFormats.Add("~/Areas/{2}/Features/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                o.AreaViewLocationFormats.Add("~/Areas/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
            });

            // Session isSession
            services.AddHttpContextAccessor()
            .Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            })
            .Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            })
            .AddDistributedMemoryCache()
            .AddMemoryCache()
            .AddSession(options =>
            {
                //options.IdleTimeout = TimeSpan.FromSeconds(2)
                //options.IdleTimeout = TimeSpan.FromDays(2)
            });

            return services;
        }
    }
}
