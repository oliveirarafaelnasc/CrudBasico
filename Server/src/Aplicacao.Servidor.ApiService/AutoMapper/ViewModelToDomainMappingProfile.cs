using Aplicacao.Servidor.ApiService.ViewModel;
using Aplicacao.Servidor.Domain.Entities;
using AutoMapper;

namespace Aplicacao.Servidor.ApiService.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
        }
    }
}
