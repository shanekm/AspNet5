using System;
using Microsoft.Owin;

namespace Mvc5.Middleware
{
    public class DebugMiddlewareOptions
    {
        public Action<IOwinContext> OnIncomingRequst { get; set; }
        public Action<IOwinContext> OnOutgoingRequest { get; set; }
    }
}