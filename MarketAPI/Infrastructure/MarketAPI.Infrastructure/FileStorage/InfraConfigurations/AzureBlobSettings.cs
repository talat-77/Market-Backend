using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAPI.Infrastructure.FileStorage.Configurations
{
    public class AzureBlobSettings
    {
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }
    }
}
