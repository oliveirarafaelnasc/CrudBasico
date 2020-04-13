using Aplicacao.Servidor.Domain.Entities;
using Aplicacao.Servidor.Domain.Interfaces;
using Aplicacao.Servidor.Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Servidor.Infra.Repository.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _db;

        public ClienteRepository(DataContext context)
        {
            _db = context;
        }
        public Cliente Adicionar(Cliente cliente)
        {
             _db.Clientes.Add(cliente);
            return cliente;
        }

        public Cliente Alterar(Cliente cliente)
        {
            _db.Entry(cliente).State = EntityState.Modified;

            return cliente;
        }

        public void Apagar(string cpfCnpj)
        {
            Cliente cliente = ObterPorCpfCnpj(cpfCnpj);
            _db.Entry(cliente).State = EntityState.Deleted;
        }


        public Cliente ObterPorCpfCnpj(string cpfCnpj)
        {
            return _db.Clientes.AsNoTracking().Where(w => w.CpfCnpj == cpfCnpj).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _db.Clientes.AsNoTracking().ToList();
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
