using HelloWorldMvc6.ViewModels;
using Microsoft.AspNet.Mvc;

namespace HelloWorldMvc6.Controllers.Web
{
    public class AppController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            // get configuration
            var email = Startup.Configuration["SiteAdminEmail"];

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}