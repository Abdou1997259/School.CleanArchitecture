﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Resources;

namespace School.Handlers.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private IEnumerable<IValidator<TRequest>> _validators;
        private IStringLocalizer<SharedResource> _stringLocalizer;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IStringLocalizer<SharedResource> stringLocalizer)
        {
            _validators = validators;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(x => x.Errors).Where(f => f != null).ToList();

                if (failures.Count > 0)
                {
                    var messages = failures.Select(x =>

                    {
                        var name = _stringLocalizer[x.PropertyName];

                        return _stringLocalizer[x.PropertyName] + " :" + _stringLocalizer[x.ErrorMessage];
                    }
                    ).FirstOrDefault();


                    throw new ValidationException(messages);
                }
            }

            return await next();
        }
    }
}
