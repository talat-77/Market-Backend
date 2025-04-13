using MarketAPI.Application.Repositories;
using MarketAPI.Domain.Entities.Common;
using MarketAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly MarketAPIDbContext _context;

        public ReadRepository(MarketAPIDbContext context)
        {
            this._context = context;
        }

        public DbSet<T> Table =>_context.Set<T>();

        public IQueryable<T> GetAll(bool tracking)
        {
            var query = Table.AsQueryable();
            if (!tracking)
             query =    query.AsNoTracking();   
            return query;
            
        }

        public async Task<T> GetByIdAsync(string id, bool tracking)
        {
            var query=Table.AsQueryable();  
            if(!tracking)
              query =  query.AsNoTracking();
            return await query.FirstOrDefaultAsync(p=>p.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking)
        //=> await Table.FirstOrDefaultAsync(method);
        {
            var query =Table.AsQueryable();
            if (!tracking)
           query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
            
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking)

        //=>  Table.Where(method);    
        {
            var query = Table.Where(method);
            if(!tracking)
              query  =  query.AsNoTracking();
            return query;
        }
        
    }
}
//buradaki tarcking optimizasyonu sağlanmıştır . Tracking datayı izlemek(takip etmek) anlamına gelir .Eğer ilgil data üzerinde bir manipülasyon yapılmayacksa 
//örneğin sadece veri olarak bir sayfada sunulacaksa tracking işlemi yapmaya gerek yok çünkü bu performans düşüklüğü getirir . Bu yüzden IReadRepository interface'inde 
//belirlenen imzalarda default bir tracking parametresi oluşturuyoruz methodların parantezine , default değeri true olarak . Tracking ile alakalı bir değiişklik yapabilmek için Queryable türünden bir değeğr dönmesi gerekiyor bu yüzden gerekli işlemleri kodda yapıyoruz.