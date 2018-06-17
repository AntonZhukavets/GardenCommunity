using System;
using GardenCommunity.Business.Interfaces;
using GardenCommunity.Business.Providers;
using GardenCommunity.DataAccess;
using GardenCommunity.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GardenCommunity.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddTransient<IDBManagerArea, DBManagerArea>();
            services.AddTransient<IDBManagerMember, DBManagerMember>();
            services.AddTransient<IDBManagerPayment, DBManagerPayment>();
            services.AddTransient<IDBManagerIndication, DBManagerIndication>();
            services.AddTransient<IDBManagerRate, DBManagerRate>();
            services.AddTransient<IDBManagerUser, DBManagerUser>();
            services.AddTransient<IDBManagerRole, DBManagerRole>();
            return services;
        }
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IMemberProvider, MemberProvider>();
            services.AddTransient<IAreaProvider, AreaProvider>();
            services.AddTransient<IPaymentProvider, PaymentProvider>();
            services.AddTransient<IIndicationProvider, IndicationProvider>();
            services.AddTransient<IRateProvider, RateProvider>();
            services.AddTransient<IUserProvider, UserProvider>();
            services.AddTransient<IRoleProvider, RoleProvider>();
            return services;
        }
    }
}
