using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Entities.Validations
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Criar arquivo de mensagens **Nome categoria nao pode ser vazio**");
        }
    }
}
