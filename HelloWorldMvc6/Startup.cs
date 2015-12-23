using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace HelloWorldMvc6
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // add mvc to DI container
            //services.AddScoped<ISomeService, SomeServiceConcrete>(); IoC interfaces
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();    // server index.html, lib/, js files etc file - NuGet package is needed

            app.UseMvc(
                config =>
                {
                    config.MapRoute(name: "Default",
                        template: "{controller}/{action}/{id?}", // ? => optional
                        defaults: new {controller = "App", action = "Index"});
                }); // use MVC
            
//            app.UseDefaultFiles();   // will look for index.html, default.html
            
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Hello World!: { context.Request.Path }");
            //});
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
