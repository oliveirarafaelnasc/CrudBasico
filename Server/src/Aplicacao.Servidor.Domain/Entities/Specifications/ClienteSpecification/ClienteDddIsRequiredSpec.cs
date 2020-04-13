using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteDddIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            string ddd = cliente.Ddd.Trim();
            ddd = ddd.TrimStart('0');
            return ddd.Length == 2;
        }
    }
}
