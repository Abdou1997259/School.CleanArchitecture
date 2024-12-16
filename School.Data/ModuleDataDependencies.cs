using Microsoft.Extensions.DependencyInjection;

namespace School.Data
{
    public static class ModuleDataDependencies
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
