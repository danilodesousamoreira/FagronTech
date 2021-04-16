using AutoFixture;

using AutoMapper;

using FagronTech.Application.AutoMapper;

using System.Linq;

namespace FagronTech.UnityTest.Service.Application
{
    public class BaseTestService
    {
        protected readonly IMapper _mapper;
        protected readonly Fixture _fixture;

        public BaseTestService()
        {
            _fixture = new Fixture();

            /*
             * Remove o comportamento padrão do AutoFixture de gerar exception em referência circular,
             * como as que acontecem em relacionamentos das entidades.
             */
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
            _mapper = new Mapper(configuration);
        }
    }
}
