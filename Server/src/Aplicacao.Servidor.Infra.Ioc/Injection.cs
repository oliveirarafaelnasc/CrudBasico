using Aplicacao.Servidor.Domain.Interfaces;
using Aplicacao.Servidor.Domain.Notifications;
using Aplicacao.Servidor.Domain.Services;
using Aplicacao.Servidor.Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao.Servidor.Infra.Ioc
{
    public class Injection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<Notificacoes>();
            
            services.AddScoped<IClienteService, ClienteService>();
            // gerar arquivo
            // services.AddScoped<IClienteRepository, Aplicacao.Servidor.Infra.Data.ClienteRepository>();

            // em memoria
            services.AddScoped<IClienteRepository, Aplicacao.Servidor.Infra.Repository.Repositories.ClienteRepository>();

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

        }
    }
}
