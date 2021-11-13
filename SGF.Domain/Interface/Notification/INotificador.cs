using SGF.Domain.Notifications;
using System.Collections.Generic;

namespace SGF.Domain.Interfaces.Notification
{
    public interface INotificador
    {
        bool TemNotificacoes();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificao);
    }
}
