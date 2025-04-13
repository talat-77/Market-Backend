using MarketAPI.Application.Repositories.CustomerRepository;
using MarketAPI.Domain.Entities;
using MarketAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Persistence.Repositories.CustomerReadRepository
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(MarketAPIDbContext context) : base(context)
        {
        }
    }
}
