using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreApi.Host;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DotNetCoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = new HostBuilder(args);
            hostBuilder.BuildWebHost()
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}
