using FluentValidation;
using FagronTech.Infrastructure.Common;
using FagronTech.Infrastructure.Domain.Entity;
using FagronTech.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Business
{
    public class CrudBusiness<TEntity> : BaseBusiness<TEntity>, ICrudBusiness<TEntity> where TEntity : BaseEntity
    {
        public CrudBusiness(IBaseRepository<TEntity> repository,
                      IValidator<TEntity> validation,
                      INotification notification)
            : base(repository,
                validation,
                notification)
        { }

        public virtual void Delete(TEntity item)
        {
            _repository.Delete(item);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(object id)
        {
            return _repository.GetById(id);
        }

        public virtual void Insert(TEntity entity)
        {
            this.ValidateExecute(_repository.Insert, "Insert", entity);
        }


        public virtual void Update(TEntity entity)
        {
            this.ValidateExecute(this._repository.Update, "Update", entity);
        }       
    }
}
