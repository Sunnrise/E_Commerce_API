using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Application.Repositories.Customers;
using ECommerceAPI.Application.Repositories.Orders;
using ECommerceAPI.Application.Repositories.Products;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.Customers;
using ECommerceAPI.Persistence.Repositories.Orders;
using ECommerceAPI.Persistence.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAPIDbContext, ECommerceAPIDbContext>(options=> options.UseNpgsql(Configurations.Configuration.ConnectionString),ServiceLifetime.Singleton);

            services.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository,OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IProductReadRepository,ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
