using MarketAPI.Domain.Entities;
using MarketAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Persistence.Contexts
{
    public class MarketAPIDbContext : DbContext
    {
        public MarketAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Productss { get; set; }
        public DbSet<Order> Orderss { get; set; }
        public DbSet<Customer> Customerss { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.UtcNow;
                }
                else if (data.State == EntityState.Modified)
                {
                    data.Entity.UpdatedDate = DateTime.UtcNow;
                }
                else
                {
                    data.Entity.UpdatedDate = DateTime.UtcNow;
                }   
            }
            return await base.SaveChangesAsync(cancellationToken);
            //Bu işlemi yapma sebeim her bir ürün kaydında ya da güncelleme işleminde tarihleri manuel olarak yazma eziyetinden kurtulma .
            //Bir güncelleme ya da bir ekleme işlemi olduğunda yukarıda yazmış olduğum interceptor araya girer ve otomatik olarak değerleri doldurur . 
            // Bu işlemi de saavechanges metodu ile yapıyoruz . data nın durumuna göre işlem yapılır . 
        }

    }

}
