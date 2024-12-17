using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using School.Core.CQRS.Students.Commands;
using School.Handlers.Behaviors;
using System.Reflection;

public static class ModuleHandlersDependencies
{
    public static IServiceCollection AddHandlersDependencies(this IServiceCollection services)
    {
        // Register MediatR services
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddStudentCommand).Assembly));

        // Register FluentValidation services
        services.AddValidatorsFromAssemblyContaining(typeof(AddStudentCommand));

        // Register AutoMapper services
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Register the ValidationBehavior pipeline
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
