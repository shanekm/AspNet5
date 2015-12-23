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
            if (ModelState.IsValid)
            {
                // get configuration
                var email = Startup.Configuration["SiteAdminEmail"];
            }

            // Adding modelstate errors
            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("", "added message");

            // Clear form and state and Form
            ModelState.Clear();

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