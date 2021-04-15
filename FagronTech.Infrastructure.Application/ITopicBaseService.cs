using FagronTech.Infrastructure.Domain.Entity;

using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Application
{
    public interface ITopicBaseService<in TEntity, in TInsertContract, in TUpdateContract> : IBaseService
        where TEntity : BaseEntity
        where TInsertContract : class
        where TUpdateContract : class
    {
  
        Task InserirAsync(TInsertContract contract);
        Task UpdateAsync(TUpdateContract contract);
    }
}
