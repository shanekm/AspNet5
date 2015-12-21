using System.Diagnostics;

using Microsoft.Owin;

using Mvc5.Middleware;

using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc5.Startup))] // Pointer to startup file
namespace Mvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //app.Use(
            //    async (ctx, next) =>
            //        {
            //            Debug.WriteLine("Incoming request: " + ctx.Request.Path);
            //            await next(); // Excute the rest of the pipeline
            //            Debug.WriteLine("Outgoing reqeust: " + ctx.Request.Path);
            //        });

            //DebugMiddlewareOptions v = new DebugMiddlewareOptions();
            //v.OnIncomingRequst = ctx =>
            //    {
            //        // IOwinContext will be passed into Method()
            //        // This is that method
            //    };

            // Whenever DebugMiddlewareOptions.OnIncomingRequst action is invoked
            // it will receive IOwinContext and will execute method body
            app.Use<DebugMiddleware>(new DebugMiddlewareOptions
                                         {
                                             OnIncomingRequst = ctx =>
                                                 {
                                                     var watch = new Stopwatch();
                                                     watch.Start();
                                                     ctx.Environment["DebugStopwatch"] = watch;
                                                 },
                                             OnOutgoingRequest = ctx =>
                                                 {
                                                     var watch = (Stopwatch)ctx.Environment["DebugStopwatch"];
                                                     watch.Stop(); 
                                                     Debug.WriteLine("Request took: " + watch.ElapsedMilliseconds + " ms");
                                                 }
                                         });

            // Adding middleware - Hello World
            // Order matters
            // ctx, next => ctx is IOwinContext, next is delegate. Returns a Task
            app.Use(
                async (ctx, next) =>
                {
                    // ctx.Response => owin.ResponseBody(string) key
                    await ctx.Response.WriteAsync("Hello World");
                });
        }
    }
}
