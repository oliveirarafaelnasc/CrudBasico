using Aplicacao.Servidor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Aplicacao.Servidor.Domain.Interfaces
{
    public interface IClienteRepository : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Alterar(Cliente cliente);
        void Apagar(string cpfCnpj);
        Cliente ObterPorCpfCnpj(string cpfCnpj);
        IEnumerable<Cliente> ObterTodos();
        int SaveChanges();
    }
}
