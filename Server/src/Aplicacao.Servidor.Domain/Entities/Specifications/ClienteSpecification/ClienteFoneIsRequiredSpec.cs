using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteFoneIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            string fone = cliente.Fone.Trim();
            fone = fone.TrimStart('0');
            return fone.Length >= 8 && fone.Length <= 9;
        }
    }
}
