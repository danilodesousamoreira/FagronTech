using FagronTech.Domain.Entities;
using FagronTech.Domain.Repositories;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Data.Repositories
{
    public class ProfissaoRepository : IProfissaoRepository
    {
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Profissao> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Profissao>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<Profissao> GetByFilter(Expression<Func<Profissao, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Profissao>> GetByFilterAsync(Expression<Func<Profissao, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Profissao GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Profissao> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Profissao entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(Profissao entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Profissao entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Profissao entity)
        {
            throw new NotImplementedException();
        }
    }
}
