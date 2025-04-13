using MarketAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T> where T : BaseEntity
    {
      IQueryable<T> GetAll(bool tracking=true);
        IQueryable<T> GetWhere(Expression<Func<T,bool>>method,bool tracking=true); //buradaki expression kullanımı linq sorguları için . Yani ben aldığım koşulu  sql e çevirip veritbanı üzerinden alıyorum sonucu .
                                                                //method buradaki girilen koşulu temsil ediyor , bool koşul sonucu döenecek olan değer 
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetByIdAsync(string id,bool tracking=true);    
    }
}
