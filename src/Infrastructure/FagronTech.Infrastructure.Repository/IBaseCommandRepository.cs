using FagronTech.Infrastructure.Domain.Entity;

using System.Collections.Generic;

namespace FagronTech.Infrastructure.Repository
{
    public interface IBaseCommandRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity item);
        void InsertRange(IEnumerable<TEntity> list);
        void Update(TEntity item);
        void UpdateRange(IEnumerable<TEntity> list);
        bool Delete(TEntity item);
        bool DeleteRange(IEnumerable<TEntity> list);
    }
}
