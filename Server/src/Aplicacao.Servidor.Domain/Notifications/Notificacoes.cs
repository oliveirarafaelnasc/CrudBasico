using Aplicacao.Servidor.Domain.Core.Validation;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Servidor.Domain.Notifications
{
    public class Notificacoes
    {
        private IList<Notificacao> _msg_Notificacoes;
        public Notificacoes()
        {
            _msg_Notificacoes = new List<Notificacao>();
        }

        public void AdicionarNotificacao(string msg)
        {
            _msg_Notificacoes.Add(new Notificacao(msg));
        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
            _msg_Notificacoes.Add(notificacao);
        }

        public void AdicionarListaNotificacao(List<Notificacao> notificacoes)
        {
            foreach(Notificacao notifiacao in notificacoes)
                AdicionarNotificacao(notifiacao);
        }

        public void AdicionarListaNotificacao(List<ValidationError> validationErrors)
        {
            foreach (ValidationError validation in validationErrors)
                AdicionarNotificacao(validation.Message);

        }
        public IReadOnlyCollection<Notificacao> Msg_Notificacoes { get { return _msg_Notificacoes.ToArray(); } }

        public bool TemNotificacao()
        {
            return Msg_Notificacoes.Count() > 0;
        }
    }
}
