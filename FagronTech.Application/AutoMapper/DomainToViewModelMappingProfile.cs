using AutoMapper;

using FagronTech.Application.ViewModels;
using FagronTech.Domain.Entities;


namespace FagronTech.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
