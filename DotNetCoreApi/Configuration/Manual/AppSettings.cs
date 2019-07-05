using DotNetCoreApi.Configuration.Manual;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApi.Configuration.Manual
{
    public class AppSettings : IAppSettings
    {
        public ISettings Settings { get; set; }

        public string StringValue { get; set; }

        public int IntValue { get; set; }

        public AppSettings(IConfiguration configuration)
        {
            this.Settings = new Settings(configuration.GetSection(nameof(Settings)));
            this.StringValue = configuration.GetValue<string>(nameof(StringValue));
            this.IntValue = configuration.GetValue<int>(nameof(IntValue));
        }
    }
}
