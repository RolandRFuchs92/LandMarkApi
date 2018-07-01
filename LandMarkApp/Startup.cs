using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandMarkAPI.Data;
using LandMarkAPI.Domain.Models;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LandMarkApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
	    
	    public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
	        var builder = new ConfigurationBuilder()
		        .SetBasePath(env.ContentRootPath)
		        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

	        Configuration = builder.Build();

		}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

	        services.AddDbContext<LandMarkContext>(cfg =>
	        {
		        cfg.UseSqlServer(Configuration.GetConnectionString("LandMarkContext"), b => b.MigrationsAssembly("DataAccess"));
	        });

			services.AddOptions();
	        services.Configure<Config>(Configuration.GetSection("Flickr"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
	        services.AddSingleton<IConfiguration>(Configuration);
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
