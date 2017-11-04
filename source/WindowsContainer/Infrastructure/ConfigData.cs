using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsContainer.Infrastructure
{
    public class ConfigData
    {
        public string ConnectionString { get; set; }
        public string CosmoUrl { get; set; }
        public string CosmoAuthKey { get; set; }
    }
}
