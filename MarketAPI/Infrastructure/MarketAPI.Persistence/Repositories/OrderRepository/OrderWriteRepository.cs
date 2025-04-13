﻿using MarketAPI.Application.Repositories.OrderRepository;
using MarketAPI.Domain.Entities;
using MarketAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Persistence.Repositories.OrderRepository
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(MarketAPIDbContext context) : base(context)
        {
        }
    }
}
