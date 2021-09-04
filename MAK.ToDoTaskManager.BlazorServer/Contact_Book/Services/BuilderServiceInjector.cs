using Microsoft.AspNetCore.Builder;

namespace Services
{
    public static class BuilderServiceInjector
    {
        public static IApplicationBuilder InjectPageNotFound(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await next();

                if(context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/not-found";
                    await next();
                }
            });

            return app;
        }
    }
}
