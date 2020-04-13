using Aplicacao.Servidor.Domain.Entities;
using Aplicacao.Servidor.Domain.Interfaces;
using Aplicacao.Servidor.Domain.Notifications;
using System.Linq;

namespace Aplicacao.Servidor.Domain.Services
{
    public class ClienteService : IClienteService
    { 
        private readonly IClienteRepository _clienteRepository;
        private readonly Notificacoes _notificacoes;
        public ClienteService(IClienteRepository clienteRepository, Notificacoes notificacoes)
        {
            _clienteRepository = clienteRepository;
            _notificacoes = notificacoes;
        }
        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.IsValid)
            {
                _notificacoes.AdicionarListaNotificacao(cliente.ValidationResult.Errors.ToList());
            }

            if (_notificacoes.TemNotificacao())
                return cliente;

            Cliente clienteExistente = _clienteRepository.ObterPorCpfCnpj(cliente.CpfCnpj);

            if (!string.IsNullOrEmpty(clienteExistente?.CpfCnpj))
            {
                _notificacoes.AdicionarNotificacao($"Cliente de CpfCnpj.: {clienteExistente.CpfCnpj} já existe no sistema!");
                return cliente;
            }

            _clienteRepository.Adicionar(cliente);

            _clienteRepository.SaveChanges();

            return cliente;

        }

        public Cliente Alterar(Cliente cliente)
        {
            if (!cliente.IsValid)
            {
                _notificacoes.AdicionarListaNotificacao(cliente.ValidationResult.Errors.ToList());
            }

            if (_notificacoes.TemNotificacao())
                return cliente;
            
            VerificarCpfCnpjExistente(cliente.CpfCnpj);

            if (_notificacoes.TemNotificacao())
                return cliente;

            _clienteRepository.Alterar(cliente);

            _clienteRepository.SaveChanges();

            return cliente;
        }

        public void Apagar(string cpfCnpj)
        {
            Cliente clienteExistente = VerificarCpfCnpjExistente(cpfCnpj);

            if (_notificacoes.TemNotificacao())
                return;

            _clienteRepository.Apagar(clienteExistente.CpfCnpj);

            _clienteRepository.SaveChanges();
        }

        private Cliente VerificarCpfCnpjExistente(string cpfCnpj)
        {
            Cliente clienteExistente = _clienteRepository.ObterPorCpfCnpj(cpfCnpj);

            if (string.IsNullOrEmpty(clienteExistente?.CpfCnpj))
            {
                _notificacoes.AdicionarNotificacao($"Cliente de CpfCnpj.: {cpfCnpj} Não encontrado para alteração!");
            }

            return clienteExistente;
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
