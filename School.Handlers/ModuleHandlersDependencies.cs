using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace School.Handlers
{
    public static class ModuleHandlersDependencies
    {
        public static IServiceCollection AddHandlersDependencies(this IServiceCollection services)
        {

            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

    }
}
