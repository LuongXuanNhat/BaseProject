using Azure.Core;
using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.RatingStars;
using BaseProject.ApiIntegration.Saves;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class SaveController : Controller
    {
        private readonly ISaveApiClient _saveApiClient;
        private readonly BaseApiClient _baseApiClient;

        public SaveController(
            ISaveApiClient saveApiClient,
            BaseApiClient baseApiClient)
        {
            _saveApiClient = saveApiClient;
            _baseApiClient = baseApiClient;
        }


        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            var request = new GetUserPagingRequest()
            {
                UserName = User.Identity.Name,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _saveApiClient.GetByUserName(request);
            ViewBag.UserName = User.Identity.Name;
            ViewBag.Token = _baseApiClient.GetToken();

            return View(data.ResultObj);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAddressToArchive([FromBody] AddAddressSaveVm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = await _saveApiClient.AddAddressToArchive(model);
            if (!data.IsSuccessed == true)
            {
                return Json(new { successMsg = data.Message});
            }
          //  ViewBag.Token = _baseApiClient.GetToken();

            return BadRequest();
        }
    }
}
