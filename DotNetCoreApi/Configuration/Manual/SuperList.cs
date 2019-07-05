using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApi.Configuration.Manual
{
    public class SuperList : ISuperList
    {
        public string Listed { get; set; }

        public string Metadata { get; set; }

        public SuperList(IConfigurationSection configurationSection)
        {
            this.Listed = configurationSection.GetValue<string>(nameof(Listed));
            this.Metadata = configurationSection.GetValue<string>(nameof(Metadata));
        }
    }
}
