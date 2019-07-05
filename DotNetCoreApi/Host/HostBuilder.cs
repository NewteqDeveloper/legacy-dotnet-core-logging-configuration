using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DotNetCoreApi.Host
{
    public class HostBuilder
    {
        private readonly string[] commandLineArgs;

        public HostBuilder()
            : this(null)
        {
        }

        public HostBuilder(string[] commandLineArgs)
        {
            this.commandLineArgs = commandLineArgs;
        }

        public IWebHostBuilder BuildWebHost(bool includeIIS = false)
        {
            var builder = BuildBasicWebHost();

            builder.AddConfiguration(this.commandLineArgs);
            builder.AddLoggingConfiguration();
            builder.AddServices();
            if (includeIIS)
            {
                builder.AddIIS();
            }

            return builder;
        }

        private IWebHostBuilder BuildBasicWebHost()
        {
            var builder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                });

            return builder;
        }
    }
}
