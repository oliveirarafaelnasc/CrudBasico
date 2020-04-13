using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteIdadeMaiorQue18IsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            if (cliente.Idade < 18)
                return false;

            var validarDataNascimento = new ClienteDataNascimentoMaiorQue18IsRequiredSpec();

            return validarDataNascimento.IsSatisfiedBy(cliente);
        }
    }
}
