using Aplicacao.Servidor.Domain.Entities;
using Aplicacao.Servidor.Domain.Entities.Specifications.ClienteSpecification;
using Aplicacao.Servidor.Domain.Entities.ValueObjects;
using System;
using Xunit;

namespace Aplicacao.Servidor.Domain.Tests.Specification
{
    public class CpfCnpjSpecificationTest
    {
        [Fact]
        public void Cpf_Valido()
        {
            Cliente cliente = new Cliente("Rafael", "122.078.400-18", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", new DateTime(1990, 1, 1), 19, 2000.00m, "oliveira_rafaelnasc@outlook.com","11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true,"observacao", "@123Rtre");
            var clienteCpfCnpjValidoIsRequiredSpec = new ClienteCpfCnpjValidoIsRequiredSpec();
            Assert.True(clienteCpfCnpjValidoIsRequiredSpec.IsSatisfiedBy(cliente));

        }

        [Fact]
        public void Cnpj_Valido()
        {
            Cliente cliente = new Cliente("Rafael", "52.168.759/0001-81", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", new DateTime(1990, 1, 1), 19, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            var clienteCpfCnpjValidoIsRequiredSpec = new ClienteCpfCnpjValidoIsRequiredSpec();
            Assert.True(clienteCpfCnpjValidoIsRequiredSpec.IsSatisfiedBy(cliente));
        }

        [Fact]
        public void Cpf_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "122.078.400-19", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", new DateTime(1990, 1, 1), 19, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            var clienteCpfCnpjValidoIsRequiredSpec = new ClienteCpfCnpjValidoIsRequiredSpec();
            Assert.False(clienteCpfCnpjValidoIsRequiredSpec.IsSatisfiedBy(cliente));
        }

        [Fact]
        public void Cnpj_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "52.168.759/0001-82", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", new DateTime(1990, 1, 1), 19, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            var clienteCpfCnpjValidoIsRequiredSpec = new ClienteCpfCnpjValidoIsRequiredSpec();
            Assert.False(clienteCpfCnpjValidoIsRequiredSpec.IsSatisfiedBy(cliente));

        }



    }
}
