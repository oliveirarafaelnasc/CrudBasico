using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;
using System;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteEnderecoCepIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            string cep = cliente.Cep.Trim();
            cep = cep.Replace("-", "");
            cep = String.Join("", System.Text.RegularExpressions.Regex.Split(cep, @"[^\d]"));
            return cep.Length == 8;
        }
    }
}
