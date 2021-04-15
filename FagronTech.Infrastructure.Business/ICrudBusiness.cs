using FagronTech.Infrastructure.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Business
{
    public interface ICrudBusiness<T> : IBaseBusiness<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object id);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);

        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);

        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
