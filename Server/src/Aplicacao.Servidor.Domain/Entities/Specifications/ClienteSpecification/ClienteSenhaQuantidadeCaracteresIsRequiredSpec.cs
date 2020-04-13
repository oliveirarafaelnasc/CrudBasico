using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteSenhaQuantidadeCaracteresIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return cliente.Senha?.Length > 5;
        }
    }
}
