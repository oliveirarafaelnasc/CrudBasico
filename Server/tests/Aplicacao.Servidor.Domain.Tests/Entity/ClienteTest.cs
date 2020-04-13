using Aplicacao.Servidor.Domain.Entities;
using Aplicacao.Servidor.Domain.Entities.ValueObjects;
using System;
using Xunit;

namespace Aplicacao.Servidor.Domain.Tests.Entity
{
    public class ClienteTest
    {

        DateTime dataNascimento = new DateTime(1990, 1, 1);
        [Fact]
        
        public void Cliente_Valido()
        {
       
            Cliente cliente = new Cliente("Rafael", "519.309.140-75", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30,
                1600.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.True(cliente.IsValid);
        }

        [Fact]
        public void Cliente_NomeInvalido_Invalido()
        {
            Cliente cliente = new Cliente("Rafa", "519.309.140-75",EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_CpfCnpj_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_Rg_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "654-7", dataNascimento, 30, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }


        [Fact]
        public void Cliente_DataNascimento_Invalido()
        {
            dataNascimento = new DateTime(2010, 1, 1);
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_Idade_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 15, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_Salario_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_Email_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_DDDEmBranco_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_DDDComZero_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "01", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_DDDComMaisCaracteres_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "0111", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_EnderecoLogradouro_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "0111", "946546654", "", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_EnderecoBairro_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "0111", "946546654", "logradouro", "1", "complemento", "", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_EnderecoCidade_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "0111", "946546654", "logradouro", "1", "complemento", "bairro", "", "uf", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_EnderecoUf_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "0111", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uff", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_EnderecoUfNaoPreenchido_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "0111", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "", "02455-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }


        [Fact]
        public void Cliente_EnderecoCep_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "0111", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "024055-654", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_EnderecoCepNaoPreenchido_Invalido()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "0111", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "", true, "observacao", "@123Rtre");
            Assert.False(cliente.IsValid);
        }

        [Fact]
        public void Cliente_Senha_Invalida()
        {
            Cliente cliente = new Cliente("Rafael", "519.309.140-77", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", dataNascimento, 30, 1500.00m, "oliveira_rafaelnascoutlook.com", "0111", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "", true, "observacao", "123");
            Assert.False(cliente.IsValid);
        }

    }


}
