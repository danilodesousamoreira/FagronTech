using AutoMapper;

using FagronTech.Infrastructure.Business;
using FagronTech.Infrastructure.Common;
using FagronTech.Infrastructure.Domain.Entity;

using FluentValidation.Results;

using System.Threading.Tasks;

namespace FagronTech.Infrastructure.Application
{
    public abstract class TopicBaseService<T, TInsertContract, TUpdateContract>
                        : BaseService, ITopicBaseService<T, TInsertContract, TUpdateContract>
        where T : BaseEntity
        where TInsertContract : class
        where TUpdateContract : class
    {
        protected readonly ICrudBusiness<T> _business;
        protected readonly INotification _notification;

        protected TopicBaseService(ICrudBusiness<T> business,
                                   INotification notification,
                                   IMapper mapper)
            : base(mapper)
        {
            _business = business;
            _notification = notification;
        }

        public virtual async Task InserirAsync(TInsertContract contract)
        {
            T entidade = this.Map<T>(contract);
            await _business.InsertAsync(entidade);
        }

        public virtual async Task UpdateAsync(TUpdateContract contract)
        {
            T entidade = await _business.GetByIdAsync(typeof(TUpdateContract).GetProperty("Id").GetValue(contract, null));
            if (entidade == default)
            {
                _notification.AddFailure(new ValidationFailure("Id", $"{nameof(T)} não encontrado(a)."));
                return;
            }

            this.Map(contract, entidade);
            await _business.UpdateAsync(entidade);
        }
    }
}
