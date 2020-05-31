using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FundMeUp.Services;
using FundMeUp.Repository;
using FundMeUp.Options;

namespace FundMeUpMVC
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
            services.AddDbContext<FundMeUpDbContext>(options =>
                options.UseSqlServer("Data Source = localhost;" + "Initial Catalog = FundMeUp; " + "Integrated Security = True;"));
            //"Server=192.168.99.100;Database=fundmeup-db;User Id=sa;Password=admin!@#123"
            services.AddScoped<IProjectManager, ProjectManager>();
            services.AddScoped<IBackerManager, BackerManager>();
            services.AddScoped<IProjectCreatorManager, ProjectCreatorManager>();

            services.AddControllersWithViews();
            services.AddLogging();
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
              if (env.IsDevelopment())
              {
                app.UseDeveloperExceptionPage();
              }
              else
              {
                app.UseExceptionHandler("/Home/Error");
              }
              app.UseStaticFiles();
      
              app.UseRouting();

            app.UseAuthorization();
            //app.UseCors();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
