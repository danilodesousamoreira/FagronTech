using FagronTech.Infrastructure.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Business
{
    public interface IReadOnlyBusiness<T> : IBaseBusiness<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
    }
}
