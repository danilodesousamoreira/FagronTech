using FluentValidation;
using FagronTech.Infrastructure.Common;
using FagronTech.Infrastructure.Domain.Entity;
using FagronTech.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Business
{
    public class CrudBusiness<T> : BaseBusiness<T>, ICrudBusiness<T> where T : BaseEntity
    {
        public CrudBusiness(IBaseRepository<T> repository,
                      IValidator<T> validation,
                      INotification notification)
            : base(repository,
                validation,
                notification)
        { }

        public virtual void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public async virtual Task DeleteAsync(object id)
            => await _repository.DeleteAsync(id);

        public virtual IEnumerable<T> GetAll()
        {
            return this._repository.GetAll();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual T GetById(object id)
        {
            return this._repository.GetById(id);
        }

        public async virtual Task<T> GetByIdAsync(object id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public virtual void Insert(T entity)
        {
            this.ValidateExecute(this._repository.Insert, "Insert", entity);
        }

        public async virtual Task InsertAsync(T entity)
        {
            await this.ValidateExecuteAsync(this._repository.InsertAsync, "Insert", entity);
        }

        public virtual void Update(T entity)
        {
            this.ValidateExecute(this._repository.Update, "Update", entity);
        }

        public async virtual Task UpdateAsync(T entity)
        {
            await this.ValidateExecuteAsync(this._repository.UpdateAsync, "Update", entity);
        }
    }
}
