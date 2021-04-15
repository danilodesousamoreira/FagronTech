using FagronTech.Infrastructure.Domain.Entity;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Repository
{
    public interface IBaseCommandRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);

        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
