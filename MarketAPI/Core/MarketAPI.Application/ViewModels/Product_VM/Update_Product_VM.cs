using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Application.ViewModels.Product_VM
{
    public class Update_Product_VM
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public string Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
