using Microsoft.AspNetCore.Mvc;

namespace BaseProject.AdminUI.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
