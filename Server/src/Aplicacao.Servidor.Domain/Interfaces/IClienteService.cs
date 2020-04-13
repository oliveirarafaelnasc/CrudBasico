using Aplicacao.Servidor.Domain.Entities;
using System;

namespace Aplicacao.Servidor.Domain.Interfaces
{
    public interface IClienteService : IDisposable 
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Alterar(Cliente cliente);
        void Apagar(string cpfCnpj);
    }
}
