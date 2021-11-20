using FluentValidation;
using SGF.Domain.Entities.Messages;

namespace SGF.Domain.Entities.Validations
{
    public class DespesaValidator : AbstractValidator<Despesa>
    {
        public DespesaValidator()
        {
            RuleFor(d => d.Valor)
                .NotEmpty().WithMessage(MessagesResource.E002);

            RuleFor(d => d.Nome)
                .NotEmpty().WithMessage(MessagesResource.E003);

        }
    }
}
