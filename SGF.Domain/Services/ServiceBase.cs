using FluentValidation;
using FluentValidation.Results;
using SGF.Domain.Entities;
using SGF.Domain.Interfaces.Notification;
using SGF.Domain.Notifications;

namespace SGF.Domain.Services
{
    public class ServiceBase 
    {
        private readonly INotificador _notificador;

        public ServiceBase(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void NotificarErrosValidator(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE: BaseEntity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;

            NotificarErrosValidator(validator);

            return false;
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
