using FagronTech.Infrastructure.Domain.Entity;

using System.Collections.Generic;

namespace FagronTech.Infrastructure.Repository
{
    public interface IBaseQueryRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
    }
}
