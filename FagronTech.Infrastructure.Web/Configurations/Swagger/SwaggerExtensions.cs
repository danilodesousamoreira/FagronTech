using System;
using FagronTech.Infrastructure.Web.Configurations.Swagger.DocumentFilters;
using FagronTech.Infrastructure.Web.Configurations.Swagger.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FagronTech.Infrastructure.Web.Configurations.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddConfiguredSwagger(this IServiceCollection services,
            IConfiguration configuration, bool forceLowercaseRoutes = true)
        {
            IConfigurationSection swaggerUiCfg = ReadSwaggerUiSettingsFromConfiguration(configuration);
            services.AddOptions<SwaggerUiSettings>().Bind(swaggerUiCfg);

            services.ConfigureOptions<CustomSwaggerGenOptions>(); // Configurações do AddSwaggerGen()
            services.ConfigureOptions<CustomSwaggerUiOptions>(); // Configurações do UseSwaggerUI()

            services.AddSwaggerGen(options =>
            {
                if (forceLowercaseRoutes)
                    options.DocumentFilter<LowerCaseDocumentFilter>();
            });

            return services;
        }

        public static IApplicationBuilder UseConfiguredSwagger(this IApplicationBuilder app)
        {
            // Versão padrão da specification para os MS é Open API 2
            app.UseSwagger(c => c.SerializeAsV2 = true);
            app.UseSwaggerUI();

            return app;
        }

        private static IConfigurationSection ReadSwaggerUiSettingsFromConfiguration(IConfiguration cfg)
        {
            IConfigurationSection cfgSection = cfg.GetSection(SwaggerUiSettings.SETTINGS_KEY);

            if (cfgSection == default || ! cfgSection.Exists())
            {
                throw new InvalidOperationException("Configuração do Swagger UI não encontrada. " +
                    "Verifique se ela foi adicionada ao appSettings.json ou nas variáveis de ambiente.");
            }

            return cfgSection;
        }
    }
}
