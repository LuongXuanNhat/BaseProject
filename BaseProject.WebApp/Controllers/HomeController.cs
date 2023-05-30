using BaseProject.ApiIntegration.Category;
using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.User;
using BaseProject.Data.Entities;
using BaseProject.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.Metadata;

namespace BaseProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserApiClient _userApiClient;
        private readonly ICategoryApiClient _cateApiClient;
        private readonly ILocationApiClient _locationApiClient;

        public HomeController(ILogger<HomeController> logger,
                    IHttpContextAccessor httpContextAccessor,
                    IUserApiClient userApiClient,
                    ICategoryApiClient cateApiClient,
                    ILocationApiClient locationApiClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _userApiClient = userApiClient;
            _cateApiClient = cateApiClient;
            _locationApiClient = locationApiClient;
        }

        public async Task<IActionResult> Index()
        {
            // Hàm để lấy danh sách danh mục
            var CategoryList = await _locationApiClient.TakeByQuantity(6);
            ViewData["ObjectList"] = CategoryList;

            var user = User.Identity.Name;
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            if (user != null && sessions == null )
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.Session.Remove("Token");
                return RedirectToAction("Index", "Home");
            }


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