using FagronTech.Domain.Entities;

using FluentValidation;
using FagronTech.Domain.Validations.Validators;

namespace FagronTech.Domain.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleSet("Insert", () =>
            {
                RuleFor(x => x.Nome).NotEmpty();
                RuleFor(x => x.Sobrenome).NotEmpty();
                RuleFor(x => x.CPF).IsValidCPF();
                RuleFor(x => x.DataNascimento).NotEmpty();
                RuleFor(x => x.ProfissaoId).NotEmpty();

            });

            RuleSet("Update", () =>
            {
                RuleFor(x => x.Id).NotEqual(0);
                RuleFor(x => x.Nome).NotEmpty();
                RuleFor(x => x.Sobrenome).NotEmpty();
                RuleFor(x => x.CPF).NotEmpty();
                RuleFor(x => x.DataNascimento).NotEmpty();
                RuleFor(x => x.ProfissaoId).NotEmpty();
            });
        }

        
    }

    public static partial class DefaultValidatorExtensions 
    {
        public static IRuleBuilderOptions<T, string> IsValidCPF<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CPFValidator());
        }
    }
}
