using BaseProject.ApiIntegration;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{

    public class PostsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPostApiClient _postApiClient;

        public PostsController(IConfiguration configuration, IPostApiClient postApiClient)
        {
            _configuration = configuration;
            _postApiClient = postApiClient;
        }


        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
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
        public async Task<IActionResult> Create([FromForm] PostCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);


            var result = await _postApiClient.CreatePost(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm bài đánh giá thành công";
                //return RedirectToAction("Index");
                return View();
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(Index);
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
            if (numberLocation.numberOfPlaces < 0)
            {
                TempData["result"] = "Số địa điểm đánh giá phải lớn hơn 0";
                return View();
            }
            if (numberLocation.numberOfPlaces == 0 || numberLocation == null  || numberLocation.numberOfPlaces == null)
            {
                numberLocation.numberOfPlaces = 1;
                return RedirectToAction("Create", numberLocation);
            }
            return RedirectToAction("Create", numberLocation);




            //var result = await _productApiClient.CreateProduct(request);
            //if (result)
            //{
            //    TempData["result"] = "Thêm mới sản phẩm thành công";
            //    return RedirectToAction("Index");
            //}

            //ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            //return View(request);
        }
    }
}
