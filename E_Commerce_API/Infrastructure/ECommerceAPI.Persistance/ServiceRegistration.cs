using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Persistance.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection service)
        {
            service.AddSingleton<IProductService, ProductService>();
        }
    }
}
