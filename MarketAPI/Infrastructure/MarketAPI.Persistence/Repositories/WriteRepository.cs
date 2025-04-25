using MarketAPI.Application.Repositories;
using MarketAPI.Domain.Entities.Common;
using MarketAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly MarketAPIDbContext _context;

        public WriteRepository(MarketAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table
            =>  _context.Set<T>();
        public async Task<bool> AddAsync(T model)
        { 
           EntityEntry<T> entityEntry = await Table.AddAsync(model); 
           return entityEntry.State == EntityState.Added;
            //EntityEntry denilen yapı entitylerin durumunu kontrol etmemizi takip etmemizi sağlayan bir entityframework yapısıdır .
            //Burada Table.AddAsync(model) ile işlemi yapıyoruz ve bunu entityEntry nesnesine atıyoruz bir alt satırında ise bu nesnenin durumunu EntityState.Added ile kontrol ediyoruz 
            //Eğer ekleme işlemi başarılysa yani kontrol doğruysa True döner. 
        }

        public async Task<bool> AddRangeAsync(List<T> model)
        {
          await Table.AddRangeAsync();
            SaveAsync();
            return true;
            
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var deleted = await Table.FindAsync(id);  
            Table.Remove(deleted);
            SaveAsync();
            return true;

        }

      

        public bool RemoveRange(List<T> model)
        {
           Table.RemoveRange(model);
            SaveAsync() ;
            return true;
        }

        public async Task<int> SaveAsync()
      => await _context.SaveChangesAsync(); 


        bool IWriteRepository<T>.Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
