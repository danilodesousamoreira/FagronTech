using FagronTech.Infrastructure.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FagronTech.Infrastructure.Repository
{
    public interface IBaseRepository<T> : IBaseCommandRepository<T>, IBaseQueryRepository<T> where T : BaseEntity
    {

    }
}
