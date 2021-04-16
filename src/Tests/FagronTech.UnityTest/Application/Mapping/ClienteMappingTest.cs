using AutoFixture;

using AutoMapper;

using FagronTech.Application.AutoMapper;
using FagronTech.Application.ViewModels;
using FagronTech.Domain.Entities;

using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace FagronTech.UnityTest.Application.Mapping
{
    public class ClienteMappingTest
    {
        private readonly Fixture builder;
        private readonly IMapper mapper;
        
        public ClienteMappingTest() 
        {
            builder = new Fixture();

            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                Profile profile = new ViewModelToDomainMappingProfile();

                // Exclui as propriedades virtual (navigations/relacionamentos) do mapeamento, pois
                // Insert/Update de Replicação não insere relacionamentos
                profile.ShouldMapProperty = propInfo => !propInfo.GetGetMethod()?.IsVirtual ?? true;

                cfg.AddProfile(profile);
            });

            mapper = new Mapper(configuration);
        }

        [Fact, Trait("ViewModelCliente", "Cliente")]
        public void InsertContract_ConfiguracaoAutoMapper_ComSucesso()
        {
            // arrange
            TypeMap insertMap = mapper.ConfigurationProvider.FindTypeMapFor<ClienteViewModel, Cliente>();

            // act & assert
            mapper.ConfigurationProvider.AssertConfigurationIsValid(insertMap);
        }

        [Fact, Trait("ViewModelCliente", "Cliente")]
        public void UpdateContract_ConfiguracaoAutoMapper_ComSucesso()
        {
            // arrange
            TypeMap updateMap = mapper.ConfigurationProvider.FindTypeMapFor<ClienteViewModel, Cliente>();

            // act & assert
            mapper.ConfigurationProvider.AssertConfigurationIsValid(updateMap);
        }

        [Fact, Trait("ViewModelCliente", "Cliente")]
        public void InsertContract_ComSucesso()
        {
            // arrange
            ClienteViewModel viewModel = builder.Create<ClienteViewModel>();

            // act
            Cliente entity = mapper.Map<Cliente>(viewModel);

            // assert
            IDictionary<string, object> contractProperties = GetNonVirtualPropertiesNameAndValue(viewModel);
            IDictionary<string, object> entityProperties = GetNonVirtualPropertiesNameAndValue(entity);

            Assert.Equal(contractProperties, entityProperties);
        }


        private IDictionary<string, object> GetNonVirtualPropertiesNameAndValue<T>(T obj)
        {
            return obj.GetType()
                .GetProperties()
                .Where(x => !x.GetGetMethod()!.IsVirtual)
                .ToDictionary(
                    keySelector: propInfo => propInfo.Name,
                    elementSelector: propInfo => propInfo.GetValue(obj)
                );
        }
    }
}
