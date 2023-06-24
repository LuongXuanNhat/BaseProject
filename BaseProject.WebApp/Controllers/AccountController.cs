using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using BaseProject.ViewModels.System.Users;
using BaseProject.BackendApi.Utilities.Constants;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Caching.Distributed;
using NuGet.Common;
using Newtonsoft.Json.Linq;
using BaseProject.ApiIntegration.User;
using FluentValidation.Results;
using Azure.Core;
using BaseProject.ApiIntegration.Nofications;

namespace BaseProject.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;
        private readonly INoficationApiClient _notiApiClient;
        private readonly IDistributedCache _cache;

        public AccountController(IUserApiClient userApiClient,
            IConfiguration configuration,
            IDistributedCache cache,
            INoficationApiClient notiApiClient)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _cache = cache;
            _notiApiClient = notiApiClient;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
                

            var result = await _userApiClient.Authenticate(request);
            if (result.ResultObj == null)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }
            var userPrincipal = this.ValidateToken(result.ResultObj);

            // Lưu cookie khi vào lại mà không logout
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                IsPersistent = true
            };
            


            HttpContext.Session.SetString(SystemConstants.AppSettings.Token, result.ResultObj);
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        authProperties);

            // Lưu cache token
            var cacheOptions = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            };
            await _cache.SetStringAsync("my_token_key", SystemConstants.AppSettings.Token, cacheOptions);

            

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestOfUser registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(registerRequest); // Trả về view và hiển thị thông báo lỗi
            }

            var result = await _userApiClient.Register(registerRequest);
            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }
            var loginResult = await _userApiClient.Authenticate(new LoginRequest()
            {
                UserName = registerRequest.UserName,
                Password = registerRequest.Password,
                RememberMe = true
            });

            var userPrincipal = this.ValidateToken(loginResult.ResultObj);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            HttpContext.Session.SetString(SystemConstants.AppSettings.Token, loginResult.ResultObj);
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        authProperties);

            return RedirectToAction("Index", "Home");
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }

        [HttpGet]
        public async Task<IActionResult> AccountSetting(string UserName)
        {
            if (UserName != null)
            {
                if (User.Identity.Name != null)
                {
                    if (!UserName.Equals(User.Identity.Name))
                    {
                        FollowViewModel followViewModel = new FollowViewModel()
                        {
                            FolloweeName = User.Identity.Name,
                            FollowerName = UserName
                        };
                        var resultt = await _userApiClient.CheckFollow(followViewModel);

                        if (resultt.IsSuccessed)
                        {
                            ViewBag.Follow = 1;
                        } else ViewBag.Follow = 0;
                    }
                }
                var result = await _userApiClient.GetByUserName(UserName);
                if (TempData["result"] != null)
                {
                    ViewBag.SuccessMsg = TempData["result"];
                }
                ViewBag.UserName = User.Identity.Name;
                return View(result.ResultObj);
            }
            else
            {
                var result = await _userApiClient.GetByUserName(User.Identity.Name);
                if (TempData["result"] != null)
                {
                    ViewBag.SuccessMsg = TempData["result"];
                }
                ViewBag.UserName = User.Identity.Name;
                return View(result.ResultObj);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _userApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new UserVm()
                {
                    Id = id,
                    Name = user.Name,
                    UserName = user.UserName,
                    Image = user.Image,
                    Email = user.Email,
                    DateOfBir = user.DateOfBir,
                    Gender = user.Gender,
                    Description = user.Description,
                    UserAddress = user.UserAddress
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserVm request)
        {
            if (!ModelState.IsValid)
                return View();

            var updateRequest = new UserUpdateRequest()
            {
                Id = request.Id,
                Name = request.Name,
                Image = request.Image,
                Email = request.Email,
                DateOfBir = request.DateOfBir,
                Gender = request.Gender,
                Description = request.Description,
                GetImage = request.GetImage,
                UserAddress = request.UserAddress
                
            };

            var result = await _userApiClient.UpdateUser(updateRequest.Id, updateRequest);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Bạn đã cập nhật thông tin thành công";
                return RedirectToAction("AccountSetting");
            }

            ModelState.AddModelError("", result.Message);
            return RedirectToAction("Error", "Home"); ;
        }
    }
}
