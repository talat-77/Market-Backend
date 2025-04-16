using MarketAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Domain.Entities
{
    public class FileInfoo : BaseEntity
    {
        public string FileName { get; set; } 
        public string FileUrl { get; set; }  
    }
}
