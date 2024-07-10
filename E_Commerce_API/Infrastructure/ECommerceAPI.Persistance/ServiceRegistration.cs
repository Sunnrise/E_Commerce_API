using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Persistance.Concretes;
using ECommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
            services.AddDbContext<ECommerceAPIDbContext>(options=> options.UseNpgsql(Configurations.Configuration.ConnectionString));
        }
    }
}
