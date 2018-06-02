using GardenCommunity.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GardenCommunity.DataAccess.DI
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddTransient<IDBManagerArea, DBManagerArea>();
            services.AddTransient<IDBManagerMember, DBManagerMember>();
            services.AddTransient<IDBManagerIndication, DBManagerIndication>();
            services.AddTransient<IDBManagerRate, DBManagerRate>();
            services.AddTransient<IDBManagerPayment, DBManagerPayment>();
            return services;
        }
    }
}
