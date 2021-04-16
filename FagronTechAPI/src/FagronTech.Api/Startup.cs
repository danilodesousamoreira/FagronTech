using Autofac;

using Fagron.Buzz.Log.ServicesExtensions;

using FagronTech.CrossCutting.IoC;

using FagronTech.Infrastructure.Web.Configurations.Swagger;
using FagronTech.Infrastructure.Web.Extensions;
using FagronTech.Infrastructure.Web.Filters;
using FagronTech.Infrastructure.Web.Middlewares;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FagronTech.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsights();
            services.AddScoped<NotificationFilter>();

            services.AddControllers(options => options.Filters.Add<NotificationFilter>());

            services.AddConfiguredSwagger(Configuration);

            services.CompressHttpCalls();
            services.ConfigureHttpJsonResponse();
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.

            builder.RegisterModule<ApplicationModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseConfiguredSwagger();

            app.UseGlobalExceptionHandler();
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
