using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteEnderecoIsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Logradouro))
                return false;
            if (string.IsNullOrEmpty(cliente.Bairro))
                return false;
            if (string.IsNullOrEmpty(cliente.Cidade))
                return false;
            if (string.IsNullOrEmpty(cliente.Estado))
                return false;
            if (string.IsNullOrEmpty(cliente.Cep))
                return false;

            return true;
        }
    }
}
