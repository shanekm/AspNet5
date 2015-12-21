using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Start web server
            string uri = "http://localhost:8080";

            // Katana component, WebApp checks the configuration within Startup.cs class
            // Configuration() method
            using (WebApp.Start<Startup>(uri)) 
            {
                Console.WriteLine("Host started!");
                Console.ReadKey(); // stop on readkey
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Using Func
            //Func<IOwinContext, Task> func = (ctx) =>
            //{
            //    return ctx.Response.WriteAsync("Hello World");
            //};
            //app.Run(func); 

            app.Run(ctx =>
            {
                return ctx.Response.WriteAsync("Hello World");
            });

            // Using custom component below
            //app.Use<HelloWorldComponent>();


            app.Use(async (env, next) =>
            {
                foreach (var pair in env.Environment)
                {
                    Console.WriteLine($"{pair.Key} : {pair.Value}"); // c# 6 
                }

                // anything before await - incoming request coming into a pipeline 

                await next(); // wait till next finishes (next stack)
                
                // anything after await is reponse coming out thru the pipeline
            });


            ConfigureWebApi(app);

            // Using extension
            app.UseHelloWorld();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApiRoute",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional});

            app.UseWebApi(config); // Plug in WebApi component
        }
    }

    // Adding custom component
    public class HelloWorldComponent
    {
        // AppFunc - using can be used to have shortened
        Func<IDictionary<string, object>, Task> _next; // AppFunc
        public HelloWorldComponent(Func<IDictionary<string, object>, Task> next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> env)
        {
            var response = env["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("Hello!");
            }

            //await _next(env); // without this it never passes to next process but return right away
        }
    }

    // To make it easy create extension method
    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }
}