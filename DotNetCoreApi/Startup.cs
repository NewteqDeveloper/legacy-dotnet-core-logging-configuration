using DotNetCoreApi.Configuration.Auto;
using DotNetCoreApi.Configuration.Manual;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace DotNetCoreApi
{
    public class Startup
    {
        private readonly IAppSettings appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this.appSettings = new AppSettings(configuration);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(this.appSettings);

            services.Configure<OptionSettings>(this.Configuration.GetSection(nameof(OptionSettings)));
            services.Configure<List<ComplexList>>(this.Configuration.GetSection($"{nameof(OptionSettings)}:{nameof(ComplexList)}"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
