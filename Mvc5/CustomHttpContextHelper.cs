using System.Web;

namespace Mvc5
{
    public static class CustomHttpContextHelper
    {
        public static void WriteToResponse()
        {
            HttpContext.Current.Response.Write("From http context helper");
        }
    }
}