using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteNomeQuantidadeCaracteresIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.Nome?.Length > 5;
        }
    }
}
