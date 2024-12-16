using Microsoft.Extensions.DependencyInjection;
using School.Core.Abstractions.Repositories;
using School.Infrastructure.Implementations.Repositories;

namespace School.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }

    }
}
