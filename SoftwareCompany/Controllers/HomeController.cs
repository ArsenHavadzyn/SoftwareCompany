using Microsoft.AspNetCore.Mvc;
using SoftwareCompany.Service;

namespace SoftwareCompany.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "My Title";
            return View();
        }
    }
}
