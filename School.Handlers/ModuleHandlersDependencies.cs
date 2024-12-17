using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using School.Handlers.Behaviors;
using System.Reflection;

public static class ModuleHandlersDependencies
{
    public static IServiceCollection AddHandlersDependencies(this IServiceCollection services)
    {
        // Register MediatR services
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Register FluentValidation services
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Register AutoMapper services
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Register the ValidationBehavior pipeline
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
