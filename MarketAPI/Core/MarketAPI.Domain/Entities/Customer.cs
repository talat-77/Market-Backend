﻿using MarketAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Domain.Entities
{
    public  class Customer:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
