using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PetSortTagHelper.Data;
using Microsoft.Extensions.Configuration;
using PetSortTagHelper.Data.Interfaces;
using PetSortTagHelper.Data.Repository;

namespace PetSortTagHelper
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            string connectionString = Configuration.GetConnectionString("default");
            services.AddDbContext<PetContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connectionString);
            });
            services.AddTransient<ICatRepository, CatRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseMvc(option =>
            {
                option.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "CatPage", action = "List" });
            });
            Initializer.Seed(app);
        }
    }
}
