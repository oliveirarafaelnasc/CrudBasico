using Aplicacao.Servidor.Domain.Core.Validation;
using Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification;

namespace Aplicacao.Servidor.Domain.Entities.Validations
{
    public class ClienteValidValidation : Validation<Cliente>
    {
        public ClienteValidValidation()
        {
            base.AddRule(new ValidationRule<Cliente>(new ClienteNomePreenchidoIsRequiredSpec(), "Nome não preenchido!"));
            base.AddRule(new ValidationRule<Cliente>(new ClienteNomeQuantidadeCaracteresIsRequiredSpec(), "Nome deve ter mais que 5 caracteres!"));

            base.AddRule(new ValidationRule<Cliente>(new ClienteCpfCnpjPreenchidoIsRequiredSpec(), "Cpf ou Cnpj não preenchido!"));
            base.AddRule(new ValidationRule<Cliente>(new ClienteCpfCnpjQuatidadeNumerosIsRequiredSpec(), "Cpf ou Cnpj deve ter mais que 5 caracteres!"));
            base.AddRule(new ValidationRule<Cliente>(new ClienteCpfCnpjValidoIsRequiredSpec(), "Cpf ou Cnpj são inválidos!"));

            base.AddRule(new ValidationRule<Cliente>(new ClienteRgPreenchidoIsRequiredSpec(), "Rg não preenchido!"));
            base.AddRule(new ValidationRule<Cliente>(new ClienteRgQuantidadeCaracteresIsRequiredSpec(), "Rg deve ter mais que 5 caracteres!"));

            base.AddRule(new ValidationRule<Cliente>(new ClienteDataNascimentoMaiorQue18IsRequiredSpec(), "Data de nascimento inválida, idade menor de 18 anos!"));
            base.AddRule(new ValidationRule<Cliente>(new ClienteIdadeMaiorQue18IsRequiredSpec(), "Data de nascimento inválida, idade menor de 18 anos!"));

            base.AddRule(new ValidationRule<Cliente>(new ClienteSalario6PorcentoIsRequiredSpec(), "Salário não atende o mínimo, não é possível realizar o cadastro!"));

            base.AddRule(new ValidationRule<Cliente>(new ClienteEmailIsRequiredSpec(), "Email inválido!"));

            base.AddRule(new ValidationRule<Cliente>(new ClienteDddIsRequiredSpec(), "Ddd inválido!"));

            base.AddRule(new ValidationRule<Cliente>(new ClienteFoneIsRequiredSpec(), "Fone inválido!"));

            base.AddRule(new ValidationRule<Cliente>(new ClienteEnderecoIsRequiredSpec(), "Endereço inválido!"));
            base.AddRule(new ValidationRule<Cliente>(new ClienteEnderecoEstadoIsRequiredSpec(), "Estado inválido!"));
            base.AddRule(new ValidationRule<Cliente>(new ClienteEnderecoCepIsRequiredSpec(), "Cep inválido!"));

            base.AddRule(new ValidationRule<Cliente>(new ClienteSenhaQuantidadeCaracteresIsRequiredSpec(), "Senha com quantidade de caracteres inválida!"));

        }
    }
}



