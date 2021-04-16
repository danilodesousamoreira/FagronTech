using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FagronTech.Infrastructure.Web.Configurations.Swagger.Options
{
    public class CustomSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly SwaggerUiSettings _swaggerUiSettings;

        public CustomSwaggerGenOptions(IOptionsSnapshot<SwaggerUiSettings> swaggerUiConfig)
        {
            _swaggerUiSettings = swaggerUiConfig.Value;
        }

        public void Configure(SwaggerGenOptions options)
        {
            options.IncludeXmlComments(GenerateXmlCommentsFilePath());

            options.SwaggerDoc(_swaggerUiSettings.Versao, new OpenApiInfo
            {
                Title = _swaggerUiSettings.Titulo,
                Description = _swaggerUiSettings.Descricao,
                Version = _swaggerUiSettings.Versao,
                Contact = new OpenApiContact
                {
                    Name = _swaggerUiSettings.ContatoNome,
                    Url = new Uri(_swaggerUiSettings.ContatoUrl)
                }
            });

            // Action Tag: Grupo sob o qual a action aparece na UI. Por padrão, é o ControllerName.
            options.TagActionsBy(description => string.IsNullOrEmpty(description.GroupName)
                ? new[] { description.ActionDescriptor.RouteValues["controller"] }
                : new[] { description.GroupName }
            );

            /*
             * Por padrão, o DocInclusionPredicate remove actions cujo GroupName seja alterado. Como o GroupName
             * será usado para agrupar actions na UI, removemos esse comportamento.
             */
            options.DocInclusionPredicate((name, api) => true);
        }

        private static string GenerateXmlCommentsFilePath()
        {
            /*
             * Esse arquivo XML usado p/ documentação do Swagger UI é gerado pela solução por meio do
             * GenerateDocumentationFile no csproj, que por padrão recebe o nome do assembly
             */
            Assembly startupAssembly = Assembly.GetEntryAssembly();

            if (startupAssembly == null)
                throw new NullReferenceException("Assembly do Startup não encontrado");

            string basePath = AppContext.BaseDirectory;
            string fileName = startupAssembly.GetName().Name + ".xml";

            string path = Path.Combine(basePath, fileName);

            if (! File.Exists(path))
                throw new InvalidOperationException("Arquivo XML de documentação do Swagger UI não encontrado. " +
                    "Verifique se o swagger foi configurado no '.csproj' do projeto de Startup.");

            return path;
        }
    }
}
