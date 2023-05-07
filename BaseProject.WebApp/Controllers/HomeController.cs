using BaseProject.WebApp.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace BaseProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //var culture = CultureInfo.CurrentCulture.Name;
            //var viewModel = new HomeViewModel
            //{
            //    Slides = await _slideApiClient.GetAll(),
            //    FeaturedProducts = await _productApiClient.GetFeaturedProducts(culture, SystemConstants.ProductSettings.NumberOfFeaturedProducts),
            //    LatestProducts = await _productApiClient.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts),
            //};

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

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }
    }
}