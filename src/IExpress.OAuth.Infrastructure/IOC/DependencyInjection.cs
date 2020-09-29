using AutoMapper;
using EventSourcing;
using IExpress.Core.Communication.Mediator;
using IExpress.Core.Config;
using IExpress.Core.Data;
using IExpress.Core.Data.EventSourcing;
using IExpress.Core.Messages.CommonMessages.Notifications;
using IExpress.OAuth.Application.AutoMapper;
using IExpress.OAuth.Application.Commands;
using IExpress.OAuth.Domain.DomainObjects;
using IExpress.OAuth.Infrastructure.Data.Contexts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using System;
using Serilog;

namespace IExpress.OAuth.Infrastructure.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection DependencyResolve(this IServiceCollection services, IConfiguration configuration)
        {

            //MongoDB
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
            services.AddAutoMapper(typeof(AdicionarUsuarioMappingProfile));

            //Command
            services.AddScoped<IRequestHandler<AdicionarUsuarioCommand, bool>, UsuarioCommandHandler>();

            //Event Sourcing
            services.AddSingleton<IEventStoreService, EventStoreService>();
            services.AddSingleton<IEventSourcingRepository, EventSourcingRepository>();

            services.AddDbContextPool<OAuthDbContext>
            (
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    p => p.
                    EnableRetryOnFailure
                    (
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                     )
                    .MigrationsHistoryTable("Migracoes")
                    )
            
            );
            services.AddIdentity<Usuario, IdentityRole>().AddEntityFrameworkStores<OAuthDbContext>();
            return services;
        }
    }
}
