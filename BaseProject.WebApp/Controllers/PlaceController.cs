using BaseProject.ApiIntegration.Locations;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class PlaceController : Controller
    {
        private readonly ILocationApiClient _locationApiClient;
        public PlaceController(
            ILocationApiClient locationApiClient)
        {
            _locationApiClient = locationApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> PlaceList(string keyword, string provinceName, int pageIndex = 1, int pageSize = 20 )
        {

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                ProvinceName = provinceName
            };
            var data = await _locationApiClient.GetPlacesPagings(request);
            ViewBag.Keyword = keyword;
            if (data.ResultObj != null && data.IsSuccessed == true)
            {
                ViewBag.ProvinceName = provinceName;
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int ID, string provinceName)
        {
            ViewBag.ProvinceName = provinceName;
            var result = await _locationApiClient.GetByIdDetail(ID);
            return View(result.ResultObj);
        }
    }
}
