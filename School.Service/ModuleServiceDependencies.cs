using Microsoft.Extensions.DependencyInjection;
using School.Core.Abstractions.Services;
using School.Service.Services;

namespace School.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}
