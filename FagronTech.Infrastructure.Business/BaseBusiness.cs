using FluentValidation;
using FagronTech.Infrastructure.Common;
using FagronTech.Infrastructure.Domain.Entity;
using FagronTech.Infrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Business
{
    public class BaseBusiness<T> : IBaseBusiness<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repository;
        protected readonly IValidator<T> _validation;
        protected readonly INotification _notification;

        public BaseBusiness(IBaseRepository<T> repository,
                            IValidator<T> validation,
                            INotification notification)
        {
            this._repository = repository;
            this._validation = validation;
            this._notification = notification;
        }

        public virtual void ValidateExecute(Action<T> func, string ruleSetName, T entity)
        {
            FluentValidation.Results.ValidationResult result = this._validation.Validate(entity, options => options.IncludeRuleSets(ruleSetName));

            if (result.IsValid)
            {
                func.Invoke(entity);
            }
            else
            {
                this._notification.AddFailures(result.Errors);
            }
        }

        public virtual async Task ValidateExecuteAsync(Func<T, Task> func, string ruleSetName, T entity)
        {
            FluentValidation.Results.ValidationResult result = await this._validation.ValidateAsync(entity, options => options.IncludeRuleSets(ruleSetName));

            if (result.IsValid)
            {
                await func.Invoke(entity);
            }
            else
            {
                this._notification.AddFailures(result.Errors);
            }
        }
    }
}
