using FagronTech.Domain.Business.Interfaces;
using FagronTech.Domain.Entities;
using FagronTech.Domain.Repositories;
using FagronTech.Infrastructure.Business;
using FagronTech.Infrastructure.Common;

using FluentValidation;

using System;
using System.Collections.Generic;

namespace FagronTech.Domain.Business
{
    public class ClienteBusiness : CrudBusiness<Cliente>, IClienteBusiness
    {
        public ClienteBusiness(IClienteRepository repository,
           IValidator<Cliente> validator,
           INotification notification)
           : base(repository, validator, notification)
        { }

        public override IEnumerable<Cliente> GetAll()
        {
            return new List<Cliente>() {
                new Cliente
                {
                    Id = 1,
                    Nome = "Danilo",
                    Sobrenome = "Moreira",
                    DataNascimento = new DateTime(1994, 6, 13),
                    CPF = "122.880.486-97",
                    ProfissaoId = 1
                    //,
                    //Profissao = new Profissao()
                    //{ 
                    //    Id = 1,
                    //    NomeProfissao = "QA"
                    //}
                }
            };
        }

        public override Cliente GetById(object id)
        {
            return new Cliente
            {
                Id = 1,
                Nome = "Danilo",
                Sobrenome = "Moreira",
                DataNascimento = new DateTime(1994, 6, 13),
                CPF = "122.880.486-97",
                ProfissaoId = 1,
                Profissao = new Profissao()
                {
                    Id = 1,
                    NomeProfissao = "QA"
                }
            };
        }
    }
}
