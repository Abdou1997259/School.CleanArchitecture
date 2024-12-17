using Microsoft.Extensions.DependencyInjection;
using School.Core.Abstractions.Repositories;
using School.Core.Bases;
using School.Infrastructure.Bases;
using School.Infrastructure.Implementations.Repositories.StudentRepositories;

namespace School.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
