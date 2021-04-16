using FagronTech.Domain.Entities;

using FluentValidation;
using FagronTech.Domain.Validations.Validators;
using System;

namespace FagronTech.Domain.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleSet("Insert", () =>
            {
                RuleFor(x => x.Nome).NotEmpty().MaximumLength(30);
                RuleFor(x => x.Sobrenome).NotEmpty().MaximumLength(100);
                RuleFor(x => x.CPF).IsValidCPF().MaximumLength(11);
                RuleFor(x => x.DataNascimento).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.ProfissaoId).NotEmpty().NotEqual(0);

            });

            RuleSet("Update", () =>
            {
                RuleFor(x => x.Id).NotEqual(0);
                RuleFor(x => x.Nome).NotEmpty().MaximumLength(30);
                RuleFor(x => x.Sobrenome).NotEmpty().MaximumLength(100);
                RuleFor(x => x.CPF).IsValidCPF().MaximumLength(11);
                RuleFor(x => x.DataNascimento).NotEmpty().LessThan(DateTime.Now);
                RuleFor(x => x.ProfissaoId).NotEmpty().NotEqual(0);
            });
        }
    }

    public static partial class DefaultValidatorExtensions 
    {
        public static IRuleBuilderOptions<T, string> IsValidCPF<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CPFValidator()).WithMessage("CPF inválido.");
        }
    }
}
