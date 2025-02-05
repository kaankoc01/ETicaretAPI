using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entitites;
using ETicaretAPI.Domain.Entitites.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
          //  ChangeTracker entityler üzerinden yapılan değişikliklerin yada yeni eklenen verinin yakalanmasını sağlayan propertydir.
          // Update operasyonlarında Track edilen verileri yakalyıp elde etmemizi sağlar.

          var datas = ChangeTracker
              .Entries<BaseEntity>();
          foreach (var data in datas)
          {
              var result = data.State switch
              {
                  EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                  EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                  _ =>  DateTime.UtcNow

              };
          }
           return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
