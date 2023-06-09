﻿using BaseProject.ApiIntegration.Category;
using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.Nofications;
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
        private readonly INoficationApiClient _notiApiClient;
        private readonly ILocationApiClient _locationApiClient;

        public HomeController(ILogger<HomeController> logger,
                    IHttpContextAccessor httpContextAccessor,
                    IUserApiClient userApiClient,
                    ICategoryApiClient cateApiClient,
                    ILocationApiClient locationApiClient,
                    INoficationApiClient notiApiClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _userApiClient = userApiClient;
            _cateApiClient = cateApiClient;
            _locationApiClient = locationApiClient;
            _notiApiClient = notiApiClient;
        }

        public async Task<IActionResult> Index()
        {
            // Hàm để lấy danh sách địa điểm
            var LocationList = await _locationApiClient.TakeByQuantity(6);
            ViewData["ObjectList"] = LocationList;
            
            // Hàm để lấy danh sách top writer
            var TopList = await _userApiClient.TakeByQuantity(4);
            ViewData["ObjectTopList"] = TopList;

            var user = User.Identity.Name;
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            if (user != null && sessions == null )
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.Session.Remove("Token");
                
                return RedirectToAction("Index", "Home");
            }
            if (User.Identity.Name != null)
            {
                var username = User.Identity.Name;
                var Notification = await _notiApiClient.GetNofiUser(username);
                ViewData["ObjectListNoti"] = Notification.ResultObj;
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