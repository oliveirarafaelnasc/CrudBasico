using Aplicacao.Servidor.Domain.Entities;
using Aplicacao.Servidor.Domain.Entities.ValueObjects;
using Aplicacao.Servidor.Domain.Interfaces;
using Aplicacao.Servidor.Domain.Notifications;
using Aplicacao.Servidor.Domain.Services;
using Moq;
using System;
using Xunit;

namespace Aplicacao.Servidor.Domain.Tests.Service
{
    public class ClienteServiceTest
    {
        Cliente clienteNull = null;
        Cliente clienteValido = new Cliente("rafael", "687.872.670-04", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", new DateTime(1990, 1, 1), 30, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
        Cliente clienteNovo = new Cliente("bruno n", "687.872.670-04", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", new DateTime(1990, 1, 1), 30, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
        Cliente clienteInValido = new Cliente("rafael", "682.872.670-04", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", new DateTime(1990, 1, 1), 30, 2000.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");

        [Fact]
        public void Cliente_IncluidoComSucesso_RetornoValido()
        {
            //Arrange
            var mockRepository = new Mock<IClienteRepository>(MockBehavior.Strict);
            Notificacoes notificacoes = new Notificacoes();
            IClienteService clienteService = new ClienteService(mockRepository.Object, notificacoes);
            mockRepository.Setup(s => s.ObterPorCpfCnpj(clienteValido.CpfCnpj)).Returns(clienteNull);
            mockRepository.Setup(s => s.Adicionar(clienteValido)).Returns(clienteValido);
            mockRepository.Setup(s => s.SaveChanges()).Returns(1);

            //Act
            clienteValido = clienteService.Adicionar(clienteValido);

            //Assert
            Assert.True(clienteValido.IsValid);


            mockRepository.Verify(mock => mock.ObterPorCpfCnpj(clienteValido.CpfCnpj), Times.Once);
            mockRepository.Verify(mock => mock.Adicionar(clienteValido), Times.Once);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Cliente_NaoDeveIncluir_CpfInvalido_RetornoValido()
        {
            //Arrange
            var mockRepository = new Mock<IClienteRepository>(MockBehavior.Strict);
            Notificacoes notificacoes = new Notificacoes();
            IClienteService clienteService = new ClienteService(mockRepository.Object, notificacoes);
            mockRepository.Setup(s => s.ObterPorCpfCnpj(clienteInValido.CpfCnpj)).Returns(clienteNull);
            mockRepository.Setup(s => s.Adicionar(clienteInValido)).Returns(clienteInValido);
            mockRepository.Setup(s => s.SaveChanges()).Returns(1);

            //Act
            clienteValido = clienteService.Adicionar(clienteInValido);

            //Assert
            Assert.True(!clienteValido.IsValid);
            Assert.True(notificacoes.TemNotificacao());

            mockRepository.Verify(mock => mock.ObterPorCpfCnpj(clienteNovo.CpfCnpj), Times.Never);
            mockRepository.Verify(mock => mock.Adicionar(clienteNovo), Times.Never);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Never);
        }

        [Fact]
        public void Cliente_NaoDeveIncluir_CpfJaExiste_RetornoInvalido()
        {
            //Arrange
            var mockRepository = new Mock<IClienteRepository>(MockBehavior.Strict);
            Notificacoes notificacoes = new Notificacoes();
            IClienteService clienteService = new ClienteService(mockRepository.Object, notificacoes);
            mockRepository.Setup(s => s.ObterPorCpfCnpj(clienteNovo.CpfCnpj)).Returns(clienteValido);
            mockRepository.Setup(s => s.Adicionar(clienteNovo)).Returns(clienteNovo);
            mockRepository.Setup(s => s.SaveChanges()).Returns(1);

            //Act
            clienteValido = clienteService.Adicionar(clienteNovo);

            //Assert
            Assert.True(clienteValido.IsValid);
            Assert.True(notificacoes.TemNotificacao());

            mockRepository.Verify(mock => mock.ObterPorCpfCnpj(clienteNovo.CpfCnpj), Times.Once);
            mockRepository.Verify(mock => mock.Adicionar(clienteNovo), Times.Never);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Never);
        }

        [Fact]
        public void Cliente_Alterar_RetornoValido()
        {
            //Arrange
            var mockRepository = new Mock<IClienteRepository>(MockBehavior.Strict);
            Notificacoes notificacoes = new Notificacoes();
            IClienteService clienteService = new ClienteService(mockRepository.Object, notificacoes);
            mockRepository.Setup(s => s.ObterPorCpfCnpj(clienteValido.CpfCnpj)).Returns(clienteValido);
            mockRepository.Setup(s => s.Alterar(clienteValido)).Returns(clienteValido);
            mockRepository.Setup(s => s.SaveChanges()).Returns(1);

            //Act
            clienteValido = clienteService.Alterar(clienteValido);

            //Assert
            Assert.True(clienteValido.IsValid);
            Assert.True(!notificacoes.TemNotificacao());

            mockRepository.Verify(mock => mock.ObterPorCpfCnpj(clienteValido.CpfCnpj), Times.Once);
            mockRepository.Verify(mock => mock.Alterar(clienteValido), Times.Once);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Cliente_Alterar_NaoEncontrou_RetornoInvalido()
        {
            //Arrange
            var mockRepository = new Mock<IClienteRepository>(MockBehavior.Strict);
            Notificacoes notificacoes = new Notificacoes();
            IClienteService clienteService = new ClienteService(mockRepository.Object, notificacoes);
            mockRepository.Setup(s => s.ObterPorCpfCnpj(clienteNovo.CpfCnpj)).Returns(clienteNull);
            mockRepository.Setup(s => s.Alterar(clienteNovo)).Returns(clienteNull);
            mockRepository.Setup(s => s.SaveChanges()).Returns(1);

            //Act
            clienteNovo = clienteService.Alterar(clienteNovo);

            //Assert
            Assert.True(clienteNovo.IsValid);
            Assert.True(notificacoes.TemNotificacao());

            mockRepository.Verify(mock => mock.ObterPorCpfCnpj(clienteNovo.CpfCnpj), Times.Once);
            mockRepository.Verify(mock => mock.Alterar(clienteNovo), Times.Never);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Never);
        }

        [Fact]
        public void Cliente_Apagar_RetornoValido()
        {
            //Arrange
            var mockRepository = new Mock<IClienteRepository>(MockBehavior.Strict);
            Notificacoes notificacoes = new Notificacoes();
            IClienteService clienteService = new ClienteService(mockRepository.Object, notificacoes);
            mockRepository.Setup(s => s.ObterPorCpfCnpj(clienteValido.CpfCnpj)).Returns(clienteValido);
            mockRepository.Setup(s => s.Apagar(clienteValido.CpfCnpj));
            mockRepository.Setup(s => s.SaveChanges()).Returns(1);

            //Act
            clienteService.Apagar(clienteValido.CpfCnpj);

            //Assert
            Assert.True(!notificacoes.TemNotificacao());

            mockRepository.Verify(mock => mock.ObterPorCpfCnpj(clienteValido.CpfCnpj), Times.Once);
            mockRepository.Verify(mock => mock.Apagar(clienteValido.CpfCnpj), Times.Once);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Cliente_Apagar_NaoEncontrou_RetornoInvalido()
        {
            //Arrange
            var mockRepository = new Mock<IClienteRepository>(MockBehavior.Strict);
            Notificacoes notificacoes = new Notificacoes();
            IClienteService clienteService = new ClienteService(mockRepository.Object, notificacoes);
            mockRepository.Setup(s => s.ObterPorCpfCnpj(clienteNovo.CpfCnpj)).Returns(clienteNull);
            mockRepository.Setup(s => s.Apagar(clienteNovo.CpfCnpj));
            mockRepository.Setup(s => s.SaveChanges()).Returns(1);

            //Act
            clienteService.Apagar(clienteNovo.CpfCnpj);

            //Assert
            Assert.True(notificacoes.TemNotificacao());

            mockRepository.Verify(mock => mock.ObterPorCpfCnpj(clienteNovo.CpfCnpj), Times.Once);
            mockRepository.Verify(mock => mock.Apagar(clienteNovo.CpfCnpj), Times.Never);
            mockRepository.Verify(mock => mock.SaveChanges(), Times.Never);
        }
    }
}
