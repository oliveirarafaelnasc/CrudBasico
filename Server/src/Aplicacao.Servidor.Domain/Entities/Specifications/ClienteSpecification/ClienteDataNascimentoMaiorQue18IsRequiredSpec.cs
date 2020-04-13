using Aplicacao.Servidor.Domain.Core.Interfaces.Specification;
using System;

namespace Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification
{
    public class ClienteDataNascimentoMaiorQue18IsRequiredSpec : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            DateTime dataInformada = cliente.DataNascimento.Date;

            int idade = DateTime.Now.Year - dataInformada.Year;

            if (DateTime.Now.Month < dataInformada.Month || (DateTime.Now.Month == dataInformada.Month && DateTime.Now.Day < dataInformada.Day))
                idade--;

            if (idade != cliente.Idade)
                return false;

            return idade >= 18;
        }
    }
}
