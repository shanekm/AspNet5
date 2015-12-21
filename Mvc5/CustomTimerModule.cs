using System;
using System.Web;

namespace Mvc5
{
    public class CustomTimerModule : IHttpModule
    {
        public void Dispose()
        {
            // nothing
        }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += app_BeginRequest;
            app.EndRequest += app_EndRequest;
        }

        // Application is the sender
        private void app_EndRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            app.Context.Items["TimerTime"] = DateTime.Now;
        }

        private void app_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
           // DateTime t = (DateTime)app.Context.Items["TimerTime"];
        }
    }
}