using BaseProject.ApiIntegration;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using BaseProject.Data.Entities;

namespace BaseProject.WebApp.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPostApiClient _postApiClient;
        //private readonly UserManager<AppUser> _userManager;

        public PostsController(IConfiguration configuration, IPostApiClient postApiClient)
        {
            _configuration = configuration;
            _postApiClient = postApiClient;
        }

        [Authorize]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var user = User.Identity.Name;

            //AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                UserName = user
            };
            var data = await _postApiClient.GetUsersPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
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

            PostDetailRequest detailRequest = new PostDetailRequest();
            List<PostDetailRequest> postDetailRequest = new List<PostDetailRequest>();
            for (int i = 0; i < numberLocation.numberOfPlaces; i++)
            {
                postDetailRequest.Add(detailRequest);
            }

            return View(
                new PostCreateRequest
                {
                    PostDetail = postDetailRequest
                }
            );
                
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCreateRequest request)
        {
            request.numberLocation = new TakeNumberLocation();
            request.UserId = "UserFake";

            request.UserId = User.Identity.Name;
            var result = await _postApiClient.CreatePost(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm bài đánh giá thành công";
                //return RedirectToAction("Index");
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
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
    }
}
