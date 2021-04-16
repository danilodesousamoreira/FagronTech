using FluentValidation.Results;

using System;
using System.Collections.Generic;

namespace FagronTech.Infrastructure.Common
{
    public interface INotification
    {
        void AddException(Exception exception);
        void AddFailures(IEnumerable<ValidationFailure> validationFailures);
        void AddFailure(ValidationFailure validationFailure);
        IEnumerable<Exception> GetException();
        IEnumerable<ValidationFailure> GetFailures();
    }
}
