using FluentValidation;
using SGF.Domain.Entities.Messages;

namespace SGF.Domain.Entities.Validations
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(MessagesResource.E001);
        }
    }
}
