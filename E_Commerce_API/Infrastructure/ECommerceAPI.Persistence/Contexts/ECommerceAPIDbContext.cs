using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceAPIDbContext : DbContext
    {
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: It is a collection of all the entities that are being tracked by the DbContext.
            //ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList().ForEach(e =>
            //{
            //    e.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
            //});
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach(var data in datas)
            {
                 _ = data.State switch
                {
                    EntityState.Added => data.CurrentValues[nameof(BaseEntity.CreatedAt)] = DateTime.UtcNow,
                    EntityState.Modified => data.CurrentValues[nameof(BaseEntity.UpdatedAt)] = DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
