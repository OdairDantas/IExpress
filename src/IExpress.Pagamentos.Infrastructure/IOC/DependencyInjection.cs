using EventSourcing;
using IExpress.Core.Communication.Mediator;
using IExpress.Core.Data.EventSourcing;
using IExpress.Core.Messages.CommonMessages.Notifications;
using IExpress.Pagamentos.AntiCorruption;
using IExpress.Pagamentos.Application.Events;
using IExpress.Pagamentos.Infrastructure.Data.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IExpress.Core.Messages.CommonMessages.IntegrationEvents;
using IExpress.Pagamentos.Domain.Service;
using IExpress.Pagamentos.Application.Services;
using IExpress.Pagamentos.Domain.Repositories;
using IExpress.Pagamentos.Infrastructure.Data.Repositories;
using IExpress.Pagamentos.Application.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using MongoDB.Bson.Serialization;
using IExpress.Core.Data;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using System;
using IExpress.Core.Config;

namespace IExpress.Pagamentos.Infrastructure.IOC
{
    public static class DependencyInjection
    {

        public static IServiceCollection DependencyResolve(this IServiceCollection services, IConfiguration configuration)
        {

            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            services.AddScoped(typeof(MongoDbContext<>));

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            MongoConfig.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
            MongoConfig.DatabaseName = configuration.GetSection("MongoConnection:Database").Value;
            MongoConfig.IsSSL = Convert.ToBoolean(configuration.GetSection("MongoConnection:IsSSL").Value);


            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Event Sourcing
            services.AddSingleton<IEventStoreService, EventStoreService>();
            services.AddSingleton<IEventSourcingRepository, EventSourcingRepository>();

            //Pagamento

            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoAppService, PagamentoAppService>();
            services.AddScoped<IPagamentoCartaoFacade, PagamentoCartaoFacade>();
            services.AddScoped<IPayPalGateway, PayPalGateway>();
            services.AddScoped<IConfigurationManager, ConfigurationManager>();
            services.AddScoped<PagamentoContext>();

            services.AddScoped<INotificationHandler<PedidoEstoqueConfirmadoEvent>, PagamentoEventHandler>();
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
            services.AddDbContext<PagamentoContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IApplicationBuilder MigrationResolve(this IApplicationBuilder app)
        {

            using (var migrationSvcScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                migrationSvcScope.ServiceProvider.GetService<PagamentoContext>().Database.Migrate();
            }

            return app;
        }
    }
}
