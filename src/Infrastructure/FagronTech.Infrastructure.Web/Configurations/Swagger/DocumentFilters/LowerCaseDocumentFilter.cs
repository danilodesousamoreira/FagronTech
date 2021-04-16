using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FagronTech.Infrastructure.Web.Configurations.Swagger.DocumentFilters
{
    public class LowerCaseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            Dictionary<string, OpenApiPathItem> paths = swaggerDoc.Paths.ToDictionary(entry =>
                LowercaseRoute(entry.Key),
                entry => entry.Value
            );

            swaggerDoc.Paths = new OpenApiPaths();
            foreach ((string key, OpenApiPathItem value) in paths)
            {
                swaggerDoc.Paths.Add(key, value);
            }
        }

        /// <summary>
        /// Transforma a string de rotas em lowercase.
        /// Atenção: Os parâmetros da rota não mudam de case (exigido pelo ASP.NET Core).
        /// </summary>
        private static string LowercaseRoute(string route)
        {
            bool isParam(string path) => path.Contains("{");

            IEnumerable<string> lowercasedRouteSplit = route
                .Split('/')
                .Select(x => isParam(x) ? x : x.ToLower());

            return string.Join('/', lowercasedRouteSplit);
        }
    }
}
