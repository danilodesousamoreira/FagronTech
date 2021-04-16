using Dapper.Contrib.Extensions;

using FagronTech.Infrastructure.Domain.Entity;
using FagronTech.Infrastructure.Repository;

using System.Collections.Generic;

namespace FagronTech.Infrastructure.Data
{
    public class BaseRepository<TEntity> : ConnectionRepository, IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public TEntity GetById(object id)
        {
            return conn.Get<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return conn.GetAll<TEntity>();
        }

        public void Insert(TEntity item)
        {
            conn.Insert(item);
        }

        public void InsertRange(IEnumerable<TEntity> list)
        {
            conn.Insert(list);
        }

        public void Update(TEntity item)
        {
            conn.Update(item);
        }

        public void UpdateRange(IEnumerable<TEntity> list)
        {
            conn.Update(list);
        }

        public bool DeleteRange(IEnumerable<TEntity> list)
        {
            return conn.Delete(list);
        }

        public bool Delete(TEntity item)
        {
            return conn.Delete(item);
        }
    }
}
