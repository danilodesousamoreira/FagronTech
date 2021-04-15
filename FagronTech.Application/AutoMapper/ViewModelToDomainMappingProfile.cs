using AutoMapper;

using FagronTech.Application.ViewModels;
using FagronTech.Domain.Entities;

namespace FagronTech.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
        }
    }
}
