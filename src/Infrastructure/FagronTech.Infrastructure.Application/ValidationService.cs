using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using FagronTech.Infrastructure.Common;
using System;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Application
{
    public class ValidationService : BaseService, IValidationService
    {

        private readonly INotification _notification;

        public ValidationService(IMapper mapper,                                 
                                 INotification notification)
            : base(mapper)
        {
            _notification = notification;
        }

        public bool ValidateBy<V, T>(T param, string ruleSet) where V : IValidator
        {
            IValidator<T> validator = (IValidator<T>)Activator.CreateInstance(typeof(V));
            ValidationResult result = validator.Validate(param);

            if (!result.IsValid)
            {
                _notification.AddFailures(result.Errors);
            }

            return result.IsValid;
        }

        public async Task<bool> ValidateByAsync<V, T>(T param, string ruleSet) where V : IValidator
        {
            IValidator<T> validator = (IValidator<T>)Activator.CreateInstance(typeof(V));
            ValidationResult result = await validator.ValidateAsync(param);

            if (!result.IsValid)
            {
                _notification.AddFailures(result.Errors);
            }

            return result.IsValid;
        }
    }
}
