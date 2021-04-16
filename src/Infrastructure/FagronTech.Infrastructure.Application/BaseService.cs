using AutoMapper;

namespace FagronTech.Infrastructure.Application
{
    public class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public TSource Map<TSource>(object source)
        {
            return this._mapper.Map<TSource>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return this._mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
