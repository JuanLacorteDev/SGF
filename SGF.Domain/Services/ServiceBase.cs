using FluentValidation;
using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Domain.Services
{
    public class ServiceBase 
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE: BaseEntity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;

            //criar metodos de notificar erros de validação.

            return false;
        }
    }
}
