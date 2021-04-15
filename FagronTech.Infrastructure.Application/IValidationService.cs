using FluentValidation;

using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Application
{
    public interface IValidationService : IBaseService
    {
        bool ValidateBy<V, T>(T param, string ruleSet) where V : IValidator;
        Task<bool> ValidateByAsync<V, T>(T param, string ruleSet) where V : IValidator;
    }
}
