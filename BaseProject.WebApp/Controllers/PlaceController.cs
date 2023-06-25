using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.Category;
using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.RatingStars;
using BaseProject.ApiIntegration.Saves;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Catalog.Search;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BaseProject.WebApp.Controllers
{
    public class PlaceController : Controller
    {
        private readonly ILocationApiClient _locationApiClient;
        private readonly IRatingApiClient _ratingApiClient;
        private readonly ICategoryApiClient _cateApiClient;
        private readonly ISaveApiClient _saveApiClient;
        private readonly BaseApiClient _baseApiClient;
        public PlaceController(
            ILocationApiClient locationApiClient,
            IRatingApiClient ratingApiClient,
            ICategoryApiClient cateApiClient,
            ISaveApiClient saveApiClient,
            BaseApiClient baseApiClient)
        {
            _locationApiClient = locationApiClient;
            _ratingApiClient = ratingApiClient;
            _cateApiClient = cateApiClient;
            _baseApiClient = baseApiClient;
            _saveApiClient = saveApiClient;
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
                UserName = User.Identity.Name,
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

        public async Task<IActionResult> LocationsByCategory(string keyword, string CategoryName, int pageIndex = 1, int pageSize = 20 )
        {
            // Hàm để lấy danh sách danh mục
            var CategoryList = await _cateApiClient.GetAll(); 
            ViewData["ObjectList"] = CategoryList.ResultObj;

            // number 2 là tìm kiếm vs danh mục
            var request = new GetUserPagingRequest()
            {
                UserName = User.Identity.Name,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword2 = CategoryName,
                number = 2
            };
            var data = await _locationApiClient.GetPlacesPagings(request);
            ViewBag.Keyword = keyword;
            ViewBag.ReponseCount = data.ResultObj.TotalRecords;
            if (data.ResultObj != null && data.IsSuccessed == true)
            {
                ViewBag.CategoryName = CategoryName;
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        public async Task<IActionResult> RecommendedPlace(int number, int pageIndex = 1, int pageSize = 20 )
        {

            // number 2 là tìm kiếm vs danh mục
            var request = new GetUserPagingRequest()
            {
                UserName = User.Identity.Name,
                PageIndex = pageIndex,
                PageSize = pageSize,
                number = number
            };
            var data = await _locationApiClient.GetPlacesPagings(request);
            ViewBag.ReponseCount = data.ResultObj.TotalRecords;
            if (data.ResultObj != null && data.IsSuccessed == true)
            {
                ViewBag.SuccessMsg = TempData["result"];
                ViewBag.number = number;
            }
            return View(data.ResultObj);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int ID, string provinceName, int pageIndex = 1, int pageSize = 5)
        {
            ViewBag.Token = _baseApiClient.GetToken();
            ViewBag.UserName = User.Identity.Name;
            ViewBag.PlaceId = ID;

            var addAddressSaveVm = new AddSaveVm();

            addAddressSaveVm.Username = User.Identity.Name;
            addAddressSaveVm.Id = ID;
            addAddressSaveVm.number = 1;

            var checkSave = await _saveApiClient.Check(addAddressSaveVm);

            if (checkSave.IsSuccessed == true)
            {
              //  ViewBag.SuccessMsg = "Đã thêm địa điểm vào danh sách yêu thích";
                ViewBag.CheckSave = true;
            }
            else
            {
               // ViewBag.SuccessMsg = "Đã xóa địa điểm khỏi danh sách yêu thích";
                ViewBag.CheckSave = false;
            }

            ViewBag.ProvinceName = provinceName;

            var request = new GetUserPagingRequest()
            {
                UserName = User.Identity.Name,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var result = await _locationApiClient.GetByIdDetail(ID,request);
            return View(result.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Detaill(int ID, string provinceName, int pageIndex = 1, int pageSize = 5)
        {
            ViewBag.Token = _baseApiClient.GetToken();
            ViewBag.UserName = User.Identity.Name;
            ViewBag.PlaceId = ID;

            var addAddressSaveVm = new AddSaveVm();

            addAddressSaveVm.Username = User.Identity.Name;
            addAddressSaveVm.Id = ID;
            addAddressSaveVm.number = 1;

            var checkSave = await _saveApiClient.Check(addAddressSaveVm);

            if (checkSave.IsSuccessed == true)
            {
              //  ViewBag.SuccessMsg = "Đã thêm địa điểm vào danh sách yêu thích";
                ViewBag.CheckSave = true;
            }
            else
            {
               // ViewBag.SuccessMsg = "Đã xóa địa điểm khỏi danh sách yêu thích";
                ViewBag.CheckSave = false;
            }

            ViewBag.ProvinceName = provinceName;

            var request = new GetUserPagingRequest()
            {
                UserName = User.Identity.Name,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var result = await _locationApiClient.GetByIdDetail(ID,request);
            return View(result.ResultObj);
        }

    }
}
