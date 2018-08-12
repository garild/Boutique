﻿using Cqrs;
using Cqrs.Attributes;
using Cqrs.Decorators;
using Cqrs.Dispatcher;
using Cqrs.Factory;
using Cqrs.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Boutique.Infrastructure.DI
{
    public static class ServicesCollection
    {
        public static void AddCqrs(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.Scan(scan =>
            scan.FromAssemblies(assemblies)
            .AddClasses(classess => classess.AssignableTo(typeof(ICommandHandler<>)))
            .AddClasses(classess => classess.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<ICommandFactory, CommandFactory>();
            services.AddScoped<ICommandGateway, CommandGateway>();
            services.Decorate<ICommandGateway, NLogCommandDecorator>();

        }

    
        public static void AddAttributes(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.Scan(scan =>
            scan.FromAssemblies(assemblies)
            .AddClasses(p => p.WithAttribute(typeof(RepositoryAttribute)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.Scan(scan =>
           scan.FromAssemblies(assemblies)
           .AddClasses(p => p.WithAttribute(typeof(ServicesAttribute)))
           .AsImplementedInterfaces()
           .WithScopedLifetime());
        }
    }
}
