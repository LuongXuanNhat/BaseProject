using BaseProject.GoogleMap.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BaseProject.GoogleMap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Index"] = "AIzaSyCw2gKWfyd0HXZz6ZMhahWKkc5ww2AGvXg";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}