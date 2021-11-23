using FluentValidation;
using SGF.Domain.Entities.Messages;

namespace SGF.Domain.Entities.Validations
{
    public class ReceitaValidator : AbstractValidator<Receita>
    {
        public ReceitaValidator()
        {
            RuleFor(r => r.Valor)
                .NotNull().WithMessage(MessagesResource.E004);

            RuleFor(r => r.Descricao)
                .MaximumLength(150)
                .WithMessage(MessagesResource.E006);
        }
    }
}
