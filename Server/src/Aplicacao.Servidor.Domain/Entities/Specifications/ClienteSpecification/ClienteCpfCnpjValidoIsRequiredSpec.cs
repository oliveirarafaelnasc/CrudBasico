using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;
using Aplicacao.Servidor.Domain.Entities.ValueObjects;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteCpfCnpjValidoIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CpfCnpjValueObjects.IsValid(cliente.CpfCnpj);
        }
    }
}
