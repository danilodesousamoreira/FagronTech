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
        private IProfissaoRepository profissaoRepository;

        public ClienteBusiness(IClienteRepository repository, IProfissaoRepository profissaoRepository,
           IValidator<Cliente> validator,
           INotification notification)
           : base(repository, validator, notification)
        {
            this.profissaoRepository = profissaoRepository;
        }
        
        public override Cliente GetById(object id)
        {
            Cliente cliente = _repository.GetById(id);

            cliente.Profissao = profissaoRepository.GetById(cliente.ProfissaoId);

            return cliente;
        }
    }
}
