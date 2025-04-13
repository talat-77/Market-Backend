using MarketAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model); //burada range olarak adlandırmamızın sebei liste olarak bir ekleme işlemi yapacağımızdan kaynaklı 
        bool Remove(T model); //"Remove işlemi senkron olsa da, uygulama genelinde tutarlı bir mimari olması ve diğer asenkron metodlara uyum sağlaması için Task ile yazılmıştır."
        Task<bool> RemoveAsync(Guid id);
        bool RemoveRange(List<T> model);

        bool Update(T model);
        Task<int> SaveAsync();

    }
}
