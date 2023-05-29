using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.RatingStars;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class PlaceController : Controller
    {
        private readonly ILocationApiClient _locationApiClient;
        private readonly IRatingApiClient _ratingApiClient;
        public PlaceController(
            ILocationApiClient locationApiClient,
            IRatingApiClient ratingApiClient)
        {
            _locationApiClient = locationApiClient;
            _ratingApiClient = ratingApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> PlaceList(string keyword, string provinceName, int pageIndex = 1, int pageSize = 20 )
        {
            // number 1 là tìm kiếm vs tỉnh

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword2 = provinceName,
                number = 1
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

        public async Task<IActionResult> PlaceListByCategory(string keyword, string category, int pageIndex = 1, int pageSize = 20 )
        {
            // number 2 là tìm kiếm vs danh mục
            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword2 = category,
                number = 2
            };
            var data = await _locationApiClient.GetPlacesPagings(request);
            ViewBag.Keyword = keyword;
            if (data.ResultObj != null && data.IsSuccessed == true)
            {
                ViewBag.ProvinceName = category;
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
