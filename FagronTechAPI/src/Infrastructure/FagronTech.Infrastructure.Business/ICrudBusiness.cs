using FagronTech.Infrastructure.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Business
{
    public interface ICrudBusiness<TEntity> : IBaseBusiness<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);

        void Insert(TEntity entity);
        void Delete(TEntity item);
        void Update(TEntity entity);
    }
}
