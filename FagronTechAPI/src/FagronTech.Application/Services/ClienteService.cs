using AutoMapper;

using FagronTech.Application.Interfaces;
using FagronTech.Application.ViewModels;
using FagronTech.Domain.Business.Interfaces;
using FagronTech.Domain.Entities;
using FagronTech.Infrastructure.Application;

using System.Collections.Generic;

namespace FagronTech.Application.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteBusiness clienteBusiness;

        public ClienteService(IClienteBusiness clienteBusiness, IMapper mapper): base(mapper)
        {
            this.clienteBusiness = clienteBusiness;
        }

        public ClienteViewModel BuscarClientePorId(int id)
        {
            return Map<ClienteViewModel>(clienteBusiness.GetById(id));
        }

        public IEnumerable<ClienteViewModel> BuscarClientes()
        {
            return Map<IEnumerable<ClienteViewModel>>(clienteBusiness.GetAll());
        }

        public void Inserir(ClienteInsertViewModel clienteInsertViewModel)
        {
            var mapeamento = Map<Cliente>(clienteInsertViewModel);
            
            clienteBusiness.Insert(mapeamento);
        }

        public void Atualizar(int id, ClienteUpdateViewModel clienteUpdateViewModel)
        {
            Cliente cliente = clienteBusiness.GetById(id);

            Map(clienteUpdateViewModel, cliente);

            clienteBusiness.Update(cliente);
        }

        public void Deletar(int id)
        {
            Cliente cliente = clienteBusiness.GetById(id);

            if (cliente != null)
            {

                clienteBusiness.Delete(cliente);
            }
            else 
            {
                throw new KeyNotFoundException("Id não encontrado");
            }
        }
    }
}
