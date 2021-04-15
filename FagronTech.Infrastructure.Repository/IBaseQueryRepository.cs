using FagronTech.Infrastructure.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Repository
{
    public interface IBaseQueryRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        ICollection<T> GetByFilter(Expression<Func<T, bool>> filter);
        ICollection<T> GetAll();

        Task<ICollection<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
    }
}
