using FagronTech.Infrastructure.Common;
using FagronTech.Infrastructure.Domain.Entity;
using FagronTech.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Business
{
    public class ReadOnlyBusiness<T> : IReadOnlyBusiness<T> where T : BaseEntity
    {
        protected readonly IBaseQueryRepository<T> _repository;
        protected readonly INotification _notification;

        public ReadOnlyBusiness(IBaseQueryRepository<T> repository,
                                INotification notification)
        {
            this._repository = repository;
            this._notification = notification;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this._repository.GetAll();
        }

        public virtual T GetById(object id)
        {
            return this._repository.GetById(id);
        }

        public async virtual Task<T> GetByIdAsync(object id)
        {
            return await this._repository.GetByIdAsync(id);
        }
      
        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._repository.GetAllAsync();
        }   
    }
}
