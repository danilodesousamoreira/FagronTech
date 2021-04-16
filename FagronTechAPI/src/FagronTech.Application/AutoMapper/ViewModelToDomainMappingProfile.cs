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

            CreateMap<ClienteInsertViewModel, Cliente>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<ClienteUpdateViewModel, Cliente>()
                 .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
