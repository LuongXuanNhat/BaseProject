using Azure.Core;
using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.Category;
using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.Post;
using BaseProject.ApiIntegration.Saves;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.AdminUI.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPostApiClient _postApiClient;
        private readonly ILocationApiClient _locationApiClient;
        private readonly ICategoryApiClient _cateApiClient;
        private readonly BaseApiClient _baseApiClient;
        private readonly ISaveApiClient _saveApiClient;
        public PostsController(IConfiguration configuration,
            IPostApiClient postApiClient, ICategoryApiClient cateApiClient,
            BaseApiClient baseApiClient, ILocationApiClient locationApiClient,
            ISaveApiClient saveApiClient)
        {
            _configuration = configuration;
            _postApiClient = postApiClient;
            _cateApiClient = cateApiClient;
            _baseApiClient = baseApiClient;
            _locationApiClient = locationApiClient;
            _saveApiClient = saveApiClient;


        }

        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                UserName = null,
                number = 4,
                Keyword2 = keyword
            };
            var data = await _postApiClient.GetAllPostPagings(request);
            ViewBag.Keyword = keyword;
            ViewBag.Token = _baseApiClient.GetToken();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }


        //[HttpGet]
        //public async Task<IActionResult> Reponse(int PostId, Guid UserId, string Message)
        //{
        //    var result = await _postApiClient.Lock(UserId, PostId, Message);
        //    if (result.IsSuccessed)
        //    {
        //        TempData["result"] = "Xóa địa điểm thành công";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", result.Message);
        //    return View();

        //}



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _postApiClient.GetByIdAdmin(id);


            var addPostSaveVm = new AddSaveVm();
            addPostSaveVm.Username = User.Identity.Name;
            addPostSaveVm.Id = id;
            addPostSaveVm.number = 2;
            var checkSave = await _saveApiClient.Check(addPostSaveVm);
            var checkLike = await _postApiClient.Check(addPostSaveVm);
            if (checkSave.IsSuccessed == true)
            {
                //  ViewBag.SuccessMsg = "Đã thêm địa điểm vào danh sách yêu thích";
                ViewBag.CheckSave = true;
            }
            else
            {  // ViewBag.SuccessMsg = "Đã xóa địa điểm khỏi danh sách yêu thích";
                ViewBag.CheckSave = false;
            }
            if (checkLike.IsSuccessed == true)
            {
                ViewBag.CheckLike = true;
            }
            else { ViewBag.CheckLike = false; }


            if (result.IsSuccessed)
            {
                ViewBag.Token = _baseApiClient.GetToken();
                ViewBag.UserName = User.Identity.Name;
                var post = result.ResultObj;
                var updateRequest = new PostCreateRequest(post);
                updateRequest.UploadDate = result.ResultObj.UploadDate;

                return View(updateRequest);
            }
            return RedirectToAction("Error", "Index");
        }
    }
}
