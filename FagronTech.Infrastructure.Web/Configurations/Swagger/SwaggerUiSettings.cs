namespace FagronTech.Infrastructure.Web.Configurations.Swagger
{
    public class SwaggerUiSettings
    {
        public const string SETTINGS_KEY = "SwaggerUi";

        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Versao { get; set; } = "v1";

        public string ContatoNome { get; set; }
        public string ContatoUrl { get; set; }
    }
}
