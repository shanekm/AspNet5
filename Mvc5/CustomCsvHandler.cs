using System.Web;

namespace Mvc5
{
    public class CustomCsvHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        // Do custom processing
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/csv";
            context.Response.Write("1,2,3,4,5\r\n1,2,3,4,5");

            // Could read that file
        }
    }
}