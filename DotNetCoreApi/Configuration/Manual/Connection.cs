using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApi.Configuration.Manual
{
    public class Connection : IConnection
    {
        public string URL { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Connection(IConfigurationSection configurationSection)
        {
            this.URL = configurationSection.GetValue<string>(nameof(URL));
            this.Port = configurationSection.GetValue<int>(nameof(Port));
            this.Username = configurationSection.GetValue<string>(nameof(Username));
            this.Password = configurationSection.GetValue<string>(nameof(Password));
        }
    }
}
