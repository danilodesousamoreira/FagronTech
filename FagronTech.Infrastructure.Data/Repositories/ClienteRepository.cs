using FagronTech.Domain.Entities;
using FagronTech.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Cliente>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<Cliente> GetByFilter(Expression<Func<Cliente, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Cliente>> GetByFilterAsync(Expression<Func<Cliente, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
