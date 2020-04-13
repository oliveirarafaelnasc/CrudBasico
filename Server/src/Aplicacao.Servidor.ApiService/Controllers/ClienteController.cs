using Aplicacao.Servidor.ApiService.ViewModel;
using Aplicacao.Servidor.Domain.Entities;
using Aplicacao.Servidor.Domain.Interfaces;
using Aplicacao.Servidor.Domain.Notifications;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;

namespace Aplicacao.Servidor.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;
        private readonly Notificacoes _notificacoes;
        private readonly ILogger<ClienteController> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService, Notificacoes notificacoes, IMapper mapper, IClienteRepository clienteRepository)
            :base(notificacoes)
        {
            _logger = logger;
            _clienteService = clienteService;
            _notificacoes = notificacoes;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        [Route("incluir")]
        public IActionResult Post([FromBody]ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(clienteViewModel);
            }

            Cliente cliente = _clienteService.Adicionar(_mapper.Map<Cliente>(clienteViewModel));
            return Response(_mapper.Map<ClienteResultViewModel>(cliente), HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("alterar")]
        public IActionResult Put([FromBody]ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(clienteViewModel);
            }

            Cliente cliente = _clienteService.Alterar(_mapper.Map<Cliente>(clienteViewModel));
            return Response(_mapper.Map<ClienteResultViewModel>(cliente), HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("apagar")]
        public IActionResult Delete(string cpfcnpj)
        {
            _clienteService.Apagar(cpfcnpj);
            return Response();
        }

        [HttpGet]
        [Route("obter-por-cpfcnpj")]
        public IActionResult Get(string cpfcnpj)
        {
            return Response(_mapper.Map<ClienteResultViewModel>(_clienteRepository.ObterPorCpfCnpj(cpfcnpj)));
        }

        [HttpGet]
        [Route("obter-todos")]
        public IActionResult GetAll()
        {
            var clientes = _clienteRepository.ObterTodos();
            return Response(_mapper.Map<List<ClienteResultViewModel>>(clientes));
        }

    }
}
