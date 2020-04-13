using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteNomePreenchidoIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return !string.IsNullOrEmpty(cliente.Nome);
        }
    }
}
