using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace FagronTech.Infrastructure.Web.Configurations.Swagger.Options
{
    public class CustomSwaggerUiOptions : IConfigureOptions<SwaggerUIOptions>
    {
        private readonly IOptionsSnapshot<SwaggerUiSettings> _swaggerUiConfig;

        public CustomSwaggerUiOptions(IOptionsSnapshot<SwaggerUiSettings> swaggerUiConfig)
        {
            _swaggerUiConfig = swaggerUiConfig;
        }

        public void Configure(SwaggerUIOptions options)
        {
            string version = _swaggerUiConfig.Value.Versao;

            options.SwaggerEndpoint($"/swagger/{version}/swagger.json", version.ToUpperInvariant());
            options.RoutePrefix = string.Empty; // Deixa o swagger na rota raiz
        }
    }
}
