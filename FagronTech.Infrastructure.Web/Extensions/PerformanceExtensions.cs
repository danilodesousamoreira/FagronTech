using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FagronTech.Infrastructure.Web.Extensions
{
    public static class PerformanceExtensions
    {
        public static void CompressHttpCalls(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
            });
        }

        public static void ConfigureHttpJsonResponse(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opcoes =>
            {
                var serializerOptions = opcoes.JsonSerializerOptions;
                serializerOptions.IgnoreNullValues = true;
                serializerOptions.IgnoreReadOnlyProperties = true;
                serializerOptions.WriteIndented = true;
            });
        }
    }
}
