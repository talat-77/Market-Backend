using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Domain.Entities.Common
{
    public class BaseEntity
    {
        public DateTime UpdatedDate { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
      
    }
}
