using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteSalario6PorcentoIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            decimal salarioBase = cliente.Salario - (cliente.Salario * (0.06m));
            return salarioBase > 1500;
        }
    }
}
