using AutoMapper;

using FagronTech.Application.ViewModels;
using FagronTech.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;


namespace FagronTech.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(x => x.Idade, opt => opt.MapFrom((s, d) => RetornaIdade(s.DataNascimento)))
                .ForMember(x => x.Profissao, opt => opt.MapFrom((s,d) => s.Profissao));

            CreateMap<Profissao, ProfissaoViewModel>()
                .ForMember(x => x.Nome, opt => opt.MapFrom((s, d) => s.NomeProfissao));
        }

        public static int RetornaIdade(DateTime nascimento)
        {
            DateTime hoje = DateTime.Now;
            int idade = hoje.Year - nascimento.Year;
            if (hoje < nascimento.AddYears(idade)) idade--;

            return idade;
        }
    }
}
