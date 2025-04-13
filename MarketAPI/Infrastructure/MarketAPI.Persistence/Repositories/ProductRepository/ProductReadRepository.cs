using MarketAPI.Application.Repositories.ProductRepository;
using MarketAPI.Domain.Entities;
using MarketAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Persistence.Repositories.ProductRepository
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(MarketAPIDbContext context) : base(context)
        {
        }
    }
}
