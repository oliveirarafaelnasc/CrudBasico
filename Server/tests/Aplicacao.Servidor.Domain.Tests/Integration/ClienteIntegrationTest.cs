using Aplicacao.Servidor.ApiService;
using Aplicacao.Servidor.Domain.Entities;
using Aplicacao.Servidor.Domain.Entities.ValueObjects;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;


namespace Aplicacao.Servidor.Domain.Tests.Integration
{
    public class TestContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;
        public TestContext()
        {
            SetupClient();
        }
        private void SetupClient()
        {
            var clientOptions = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("http://localhost"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            Client = _server.CreateClient(clientOptions);
        }
    }
    public class ClienteTest 
    {

        private readonly TestContext _testContext;
        public ClienteTest()
        {
            _testContext = new TestContext();
        }

        Cliente clienteValido = new Cliente("Rafael", "519.309.140-75", EnumSexo.Masculino, EnumEstadoCivil.Casado, "24.514.654-7", new DateTime(1990, 1, 1), 30,
                 1600.00m, "oliveira_rafaelnasc@outlook.com", "11", "946546654", "logradouro", "1", "complemento", "bairro", "cidade", "uf", "02455-654", true, "observacao", "@123Rtre");
        [Fact]

        public async Task Cliente_ObterTodos_Valido()
        {
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/cliente/obter-todos");

            var response = await _testContext.Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);


        }

        [Fact]
        public async Task Cliente_ObterTodosPorCpfCnpj_Valido()
        {
            var response = await _testContext.Client.GetAsync("/api/cliente/obter-por-cpfcnpj?cpfcnpj=121495050");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Cliente_RotaErrada_Invalido()
        {
            var response = await _testContext.Client.GetAsync("/api/cliente/XXX");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Cliente_ObterTodosPorCpfCnpjTestarTipo_Valido()
        {
            var response = await _testContext.Client.GetAsync("/api/cliente/obter-por-cpfcnpj?cpfcnpj=121495050");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");
        }

        [Fact]
        public async Task Cliente_Adicionar_Valido()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(clienteValido);
            HttpContent httpContent = new StringContent(jsonString);
            //httpContent.Headers.ContentType.CharSet = "UTF-8";


            var response = await _testContext.Client.PostAsync("/api/cliente/incluir", httpContent);
            var resposta = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

    }

   
}