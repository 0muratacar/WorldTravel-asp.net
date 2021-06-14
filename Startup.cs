using city.data.Abstract;
using city.data.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WorldTravel.Models;
using WorldTravel.Services;

namespace WorldTravel
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
            services.AddRazorPages();
            // Wikipedia aramasý için yazýlan API servise eklendi.
            services.AddTransient<JsonWikiService>();

            services.AddTransient<JsonProjectService>();

            // Þehirleri iþleyen servis
            services.AddTransient<JsonCityService>();

            // IUser nesnesi çalýþtýrýldýðýnda UserRepository içerisindeki metotlarý çalýþtýran servis
            services.AddScoped<IUser, UserRepository>();

            services.AddControllers();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                //endpoints.MapGet("projects",(context) =>
                //{
                //    var projects = app.ApplicationServices.GetService<JsonProjectService>().GetProjects();
                //    var json = JsonSerializer.Serialize<IEnumerable<ProjectModel>>(projects);

                //    return context.Response.WriteAsync(json);
                //}
                //);
            });
        }
    }
}
