using MarketAPI.Application.Repositories.CustomerRepository;
using MarketAPI.Domain.Entities;
using MarketAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Persistence.Repositories.CustomerRepository
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(MarketAPIDbContext context) : base(context)
        {
        }
    }
}
