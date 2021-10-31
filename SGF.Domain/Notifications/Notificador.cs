using SGF.Domain.Interfaces.Notification;
using System.Collections.Generic;
using System.Linq;

namespace SGF.Domain.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }
        public void Handle(Notificacao notificao)
        {
            _notificacoes.Add(notificao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacoes()
        {
            return _notificacoes.Any();
        }
    }
}
