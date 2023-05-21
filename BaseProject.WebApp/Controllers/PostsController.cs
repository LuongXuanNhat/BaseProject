using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using BaseProject.Data.Entities;
using Azure.Core;
using BaseProject.ApiIntegration.Post;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using BaseProject.ApiIntegration.Category;

namespace BaseProject.WebApp.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPostApiClient _postApiClient;
        private readonly ICategoryApiClient _cateApiClient;
        //private readonly UserManager<AppUser> _userManager;

        public PostsController(IConfiguration configuration, IPostApiClient postApiClient, ICategoryApiClient cateApiClient)
        {
            _configuration = configuration;
            _postApiClient = postApiClient;
            _cateApiClient = cateApiClient;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var user = User.Identity.Name;

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                UserName = user
            };
            var data = await _postApiClient.GetUsersPagings(request);
            ViewBag.Keyword = keyword;
            ViewBag.Token = GetToken();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _postApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var post = result.ResultObj;
                var updateRequest = new PostCreateRequest(post);
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Index");

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create(TakeNumberLocation numberLocation)
        {
            //int numberLocation = 1;
            if (numberLocation == null || numberLocation.numberOfPlaces < 1)
            {
                numberLocation = new TakeNumberLocation();
            }
            ViewBag.Num = numberLocation.numberOfPlaces;
            ViewBag.Token = GetToken();

            PostDetailRequest detailRequest = new PostDetailRequest();
            List<PostDetailRequest> postDetailRequest = new List<PostDetailRequest>();
            for (int i = 0; i < numberLocation.numberOfPlaces; i++)
            {
                postDetailRequest.Add(detailRequest);
            }
            var category = await _cateApiClient.GetAll();
            return View(
                new PostCreateRequest
                {
                    PostDetail = postDetailRequest,
                    CategoryPostDetail = category.ResultObj
                }
            );
                
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCreateRequest request)
        {
            request.numberLocation = new TakeNumberLocation();
            request.PostId = 123456;
            request.UserId = User.Identity.Name;
            var result = await _postApiClient.CreatePost(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm bài đánh giá thành công";
                //return RedirectToAction("Index");
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm đánh giá thất bại");
            return View(request);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditPost(int id)
        {
            var result = await _postApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var post = result.ResultObj;
                var updateRequest = new PostCreateRequest(post);
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(PostCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _postApiClient.UpdatePost(request.PostId, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật bài viết thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> TakeNumberLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TakeNumberLocation(TakeNumberLocation numberLocation)
        {

            if (numberLocation.numberOfPlaces < 1 || numberLocation == null || numberLocation.numberOfPlaces == null)
            {
                numberLocation.numberOfPlaces = 1;
                return RedirectToAction("Create", numberLocation);
            }
            return RedirectToAction("Create", numberLocation);
        }


        public async Task<IActionResult> SearchData()
        {
            List<Location> results =await _postApiClient.GetAll();
            return Json(results);
        }

        public string GetToken()
        {
            return  _postApiClient.GetToken();

        }
    }
}
