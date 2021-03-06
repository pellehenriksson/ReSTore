﻿using System;
using ReSTore.Domain;
using ReSTore.Domain.CommandHandlers;
using ReSTore.Domain.Services;
using ReSTore.Infrastructure;
using StructureMap.Configuration.DSL;

namespace ReSTore
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            IncludeRegistry<RavenRegistry>();
            For<IPricingService>().Singleton().Use<PricingService>();
            Scan(s =>
                {
                    s.AssemblyContainingType<CreateOrderHandler>();
                    s.ConnectImplementationsToTypesClosing(typeof (ICommandHandler<>));
                });
            For<IRepository<Guid>>().Use<EventStoreRepository<Guid>>();
        }
    }
}