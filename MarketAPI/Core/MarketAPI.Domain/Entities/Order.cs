﻿using MarketAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; }

        // Foreign Key tanımlama
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

}
