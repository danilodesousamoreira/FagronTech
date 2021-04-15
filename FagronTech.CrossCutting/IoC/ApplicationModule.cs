using Autofac;
using Autofac.Extras.DynamicProxy;

using AutoMapper;

using FagronTech.Application.AutoMapper;
using FagronTech.Application.Interfaces;
using FagronTech.Application.Services;
using FagronTech.Domain.Business;
using FagronTech.Domain.Business.Interfaces;
using FagronTech.Domain.Entities;
using FagronTech.Domain.Repositories;
using FagronTech.Domain.Validations;
using FagronTech.Infrastructure.Common;
using FagronTech.Infrastructure.Data.Repositories;
using FagronTech.Infrastructure.Log.Interceptors;

using FluentValidation;

namespace FagronTech.CrossCutting.IoC
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogInterceptor>();
            //builder.RegisterType<TransactionContextInterceptor>();
            builder.RegisterType<EnviromentConfiguration>().SingleInstance();
            builder.RegisterType<Notification>().As<INotification>().InstancePerLifetimeScope();
            //builder.RegisterType<ApplicationContext>().As<ApplicationContext>().As<DbContext>().InstancePerLifetimeScope();

            /* Database */
            //builder.Register(c =>
            //{
            //    EnviromentConfiguration env = c.Resolve<EnviromentConfiguration>();
            //    DbContextOptionsBuilder<ApplicationContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            //    optionsBuilder
            //        .UseLazyLoadingProxies()
            //        .UseLoggerFactory(LoggerFactory.Create(logBuilder => logBuilder.AddConsole()))
            //        .UseSqlServer(GetConnectionString(env), options => options.CommandTimeout(60))
            //        .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);

            //    return optionsBuilder.Options;
            //});

            /* AutoMapper */
            builder.Register(c =>
            {
                MapperConfiguration config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new DomainToViewModelMappingProfile());
                    cfg.AddProfile(new ViewModelToDomainMappingProfile());

                });

                return config.CreateMapper();
            });



            /* Custom Registers */
            builder.RegisterType<ClienteService>().As<IClienteService>().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor));
            builder.RegisterType<ClienteBusiness>().As<IClienteBusiness>().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor));
            builder.RegisterType<ClienteValidation>().As<IValidator<Cliente>>();
            builder.RegisterType<ClienteRepository>().As<IClienteRepository>().EnableInterfaceInterceptors().InterceptedBy(typeof(LogInterceptor));
        }

        //private string GetConnectionString(EnviromentConfiguration env) =>
        //    string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
        //        env.GetValue("Database:Host"), env.GetValue("Database:Database"),
        //        env.GetValue("Database:User"), env.GetValue("Database:Password")
        //    );
    }
}
