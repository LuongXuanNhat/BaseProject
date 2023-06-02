using Azure.Core;
using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.RatingStars;
using BaseProject.ApiIntegration.Saves;
using BaseProject.ViewModels.Catalog.Search;
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

        public IActionResult Index()
        {
            return View();
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
            if (data.IsSuccessed == true)
            {
                ViewBag.SuccessMsg = "Đã thêm vào địa điểm yêu thích";
                return Ok();
            }
          //  ViewBag.Token = _baseApiClient.GetToken();

            return BadRequest();
        }
    }
}
