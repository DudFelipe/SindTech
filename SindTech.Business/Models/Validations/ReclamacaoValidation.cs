using FluentValidation;

namespace SindTech.Business.Models.Validations
{
    public class ReclamacaoValidation : AbstractValidator<Reclamacao>
    {
        public ReclamacaoValidation()
        {
            RuleFor(r => r.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");

            RuleFor(r => r.MoradorId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.");
        }
    }
}