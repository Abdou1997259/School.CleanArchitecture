using Microsoft.AspNetCore.Builder;
using School.Handlers.Middlewares;


namespace School.Handlers.Extension
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder AddMiddleWares(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
            return app;
        }
    }
}
