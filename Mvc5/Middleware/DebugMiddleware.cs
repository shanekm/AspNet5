using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace Mvc5.Middleware
{
    public class DebugMiddleware
    {
        private AppFunc _next;

        DebugMiddlewareOptions _options;

        // next middleware in the pipeline
        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;

            if (_options.OnIncomingRequst == null)
                _options.OnIncomingRequst = (ctx) => { Debug.WriteLine("Incoming request"); };

            if (_options.OnOutgoingRequest == null)
                _options.OnOutgoingRequest = (ctx) => { Debug.WriteLine("Outgoing request"); };

        }

        public async Task Invoke(IDictionary<string, object> envirenment)
        {
            var ctx = new OwinContext(envirenment); // need to convert to Owin context

            // Add options
            _options.OnIncomingRequst(ctx); // Action<IOwinContext> Invoke delegate in Startup.cs

            Debug.WriteLine("Incoming request: " + ctx.Request.Path);
            await _next(envirenment); // Excute the rest of the pipeline
            Debug.WriteLine("Outgoing reqeust: " + ctx.Request.Path);

            _options.OnOutgoingRequest(ctx);
        }
    }
}