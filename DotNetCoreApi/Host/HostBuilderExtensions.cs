using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using System.Reflection;

namespace DotNetCoreApi.Host
{
    public static class HostBuilderExtensions
    {
        public static IWebHostBuilder AddConfiguration(this IWebHostBuilder builder, string[] args)
        {
            return builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;

                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                if (env.IsDevelopment())
                {
                    var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                    if (appAssembly != null)
                    {
                        config.AddUserSecrets(appAssembly, optional: true);
                    }
                }

                config.AddEnvironmentVariables();

                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            });
        }

        public static IWebHostBuilder AddIIS(this IWebHostBuilder builder)
        {
            return builder.UseIISIntegration();
        }

        public static IWebHostBuilder AddLoggingConfiguration(this IWebHostBuilder builder)
        {
            return builder.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });
        }

        public static IWebHostBuilder AddServices(this IWebHostBuilder builder)
        {
            return builder.ConfigureServices(services =>
            {
                services.AddTransient<IConfigureOptions<KestrelServerOptions>, KestrelServerOptionsSetup>();
            });
        }
    }
}
