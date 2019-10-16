using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWRestaurant.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace HWRestaurant.WEB
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
            // Register My Service---> HWRestaurants.Data

            // Register EF Database and Options Connection String.
            services.AddDbContextPool<RestaurantDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("RestaurantDb"));
            });
            // Singleton, Scope and Transient
            //services.AddSingleton<IRestaurantData, SQLRestaurantData>();
            services.AddScoped<IRestaurantData, SQLRestaurantData>();

            //services.AddRazorPages();
            // different types of Injecting services in .NET Core.
            // I can also Add services.AddMvcCore() here.
            services.AddMvc(option => option.EnableEndpointRouting = false);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        

        // MiddleWare
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});

            app.UseMvcWithDefaultRoute();
        }

        //private RequestDelegate SayHelloMiddleware(RequestDelegate next) 
        //{
        //    return async ctx => 
        //    {
        //        if (ctx.Request.Path.StartsWithSegments("/hello"))
        //        {
        //            await ctx.Response.WriteAsync("Hello World");
        //        }
        //        else 
        //        {
        //            cons
        //        }
        //    }
        //}


    }
}
