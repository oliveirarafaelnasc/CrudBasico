namespace Aplicacao.Servidor.Domain.Notifications
{
    public class Notificacao
    {
        public Notificacao(string msg)
        {
            Mensagem = msg;
        }
        public string Mensagem { get; private set; }
    }
}
