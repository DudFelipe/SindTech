using FluentValidation;

namespace SindTech.Business.Models.Validations
{
    public class ContatoValidation : AbstractValidator<Contato>
    {
        public ContatoValidation()
        {
            When(c => c.TipoContato == TipoContato.Email, () =>
            {
                RuleFor(c => c.ValorContato)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                    .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                        .WithMessage("O email fornecido não é válido.");
            });

            When(c => c.TipoContato == TipoContato.Celular, () =>
            {
                RuleFor(c => c.ValorContato)
                    .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                    .Length(11).WithMessage("O campo {PropertyName} precisa ter 11 dígitos.");
            });
        }
    }
}
