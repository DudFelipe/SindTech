using FluentValidation;
using SindTech.Business.Models.Validations.Documentos;

namespace SindTech.Business.Models.Validations
{
    public class MoradorValidation : AbstractValidator<Morador>
    {
        public MoradorValidation()
        {
            RuleFor(m => m.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(3, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres.");

            RuleFor(m => m.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

            RuleFor(m => m.CPF)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(m => m.DataNascimento).NotNull().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(m => m.NumeroApartamento)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .GreaterThan(9).WithMessage("O campo {PropertyName} precisa ser maior que 9.");

        }
    }
}
