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

        /// <summary>
        /// Utilizar os dados do ValidationResult de um AbstractValidator para armazenar mensagem da propriedades invalidas.
        /// </summary>
        /// <param name="validationResult"></param>
        protected void NotificarErrosValidator(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        /// <summary>
        /// Executa validacao de acordo com o Validator da Entidade T, retorno TRUE se modelo respeitar validações.
        /// </summary>
        /// <typeparam name="TV">Validator</typeparam>
        /// <typeparam name="TE">Entidade a ser validada com o validator</typeparam>
        /// <param name="validacao"></param>
        /// <param name="entidade"></param>
        /// <returns></returns>
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE: BaseEntity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;

            NotificarErrosValidator(validator);

            return false;
        }

        /// <summary>
        /// Chamada o metodo handle no Notificar para adicionar na listagem de mensagem os erro da validação.
        /// </summary>
        /// <param name="mensagem"></param>
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
