using Aplicacao.Servidor.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace Aplicacao.Servidor.ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private readonly Notificacoes _notificacoes;
        protected BaseController(Notificacoes notificacoes)
        {
            _notificacoes = notificacoes;
        }

        protected bool IsValidOperation()
        {
            return (!_notificacoes.TemNotificacao());
        }

        protected new IActionResult Response(object result = null, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            if (IsValidOperation())
            {
                return StatusCode((int)httpStatusCode, new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificacoes.Msg_Notificacoes
            });
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                _notificacoes.AdicionarNotificacao(erroMsg);
            }
        }

        protected void NotificacaoErro(string message)
        {
            _notificacoes.AdicionarNotificacao(message);
        }


    }
}


