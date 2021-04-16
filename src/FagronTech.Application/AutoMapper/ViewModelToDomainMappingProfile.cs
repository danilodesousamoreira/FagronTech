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
            
            CreateMap<ProfissaoViewModel, Profissao>()
               .ForMember(x => x.NomeProfissao, opt => opt.MapFrom((s, d) => s.Nome));
        }
    }
}
