using FagronTech.Application.ViewModels;
using FagronTech.Infrastructure.Application;

using System.Collections.Generic;

namespace FagronTech.Application.Interfaces
{
    public interface IClienteService : IBaseService
    {
        public IEnumerable<ClienteViewModel> BuscarClientes();
        public ClienteViewModel BuscarClientePorId(int id);
        public void Inserir(ClienteInsertViewModel clienteInsertViewModel);
        public void Atualizar(int id, ClienteUpdateViewModel clienteUpdateViewModel);
        public void Deletar(int id);
    }
}
