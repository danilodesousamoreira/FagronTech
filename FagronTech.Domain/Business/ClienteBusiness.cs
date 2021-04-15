using FagronTech.Domain.Business.Interfaces;
using FagronTech.Domain.Entities;
using FagronTech.Domain.Repositories;
using FagronTech.Infrastructure.Business;
using FagronTech.Infrastructure.Common;

using FluentValidation;

namespace FagronTech.Domain.Business
{
    public class ClienteBusiness : CrudBusiness<Cliente>, IClienteBusiness
    {
        public ClienteBusiness(IClienteRepository repository,
           IValidator<Cliente> validator,
           INotification notification)
           : base(repository, validator, notification)
        { }
    }
}
