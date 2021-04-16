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
        public void InsertViewModel_ConfiguracaoAutoMapper_ComSucesso()
        {
            // arrange
            TypeMap insertMap = mapper.ConfigurationProvider.FindTypeMapFor<ClienteInsertViewModel, Cliente>();

            // act & assert
            mapper.ConfigurationProvider.AssertConfigurationIsValid(insertMap);
        }

        [Fact, Trait("ViewModelCliente", "Cliente")]
        public void UpdateViewModel_ConfiguracaoAutoMapper_ComSucesso()
        {
            // arrange
            TypeMap updateMap = mapper.ConfigurationProvider.FindTypeMapFor<ClienteUpdateViewModel, Cliente>();

            // act & assert
            mapper.ConfigurationProvider.AssertConfigurationIsValid(updateMap);
        }
    }
}
