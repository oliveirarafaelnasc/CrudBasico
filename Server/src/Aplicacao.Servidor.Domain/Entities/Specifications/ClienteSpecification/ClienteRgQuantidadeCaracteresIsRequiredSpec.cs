using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteRgQuantidadeCaracteresIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            string rgBase = cliente.Rg?.Replace(".", "").Replace("-", "");
            return rgBase.Length > 5;
        }
    }
}
