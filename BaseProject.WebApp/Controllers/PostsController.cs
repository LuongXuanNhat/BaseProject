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
using BaseProject.ApiIntegration;

namespace BaseProject.WebApp.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPostApiClient _postApiClient;
        private readonly ICategoryApiClient _cateApiClient;
        private readonly BaseApiClient _baseApiClient;
        //private readonly UserManager<AppUser> _userManager;

        public PostsController(IConfiguration configuration, 
            IPostApiClient postApiClient, ICategoryApiClient cateApiClient,
            BaseApiClient baseApiClient)
        {
            _configuration = configuration;
            _postApiClient = postApiClient;
            _cateApiClient = cateApiClient;
            _baseApiClient = baseApiClient;

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
            ViewBag.Token = _baseApiClient.GetToken();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        // Lấy tất cả bài viết
        // Nếu tìm kiếm tất cả _ Lưu lịch sử tìm kiếm
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> IndexAll(string keyword, int pageIndex = 1, int pageSize = 5)
        {

            // 3: Tìm kiếm bài viết tất cả
            var request = new GetUserPagingRequest()
            {
                UserName = User.Identity.Name,
                Keyword = keyword,
                Keyword2 = "",
                PageIndex = pageIndex,
                PageSize = pageSize,
                number = 3
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

            // max numberOfPlaces = 3;
            if (numberLocation != null && numberLocation.numberOfPlaces > 3)
            {
                numberLocation = new TakeNumberLocation(3);
            }
                        
            ViewBag.Num = numberLocation.numberOfPlaces;
            ViewBag.Token = _baseApiClient.GetToken();

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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(PostCreateRequest request, [FromForm(Name = "SelectedCategories")] string[] selectedCategories)
        {
            if (request.PostDetail.Count > 1)
            {
                //Check Not Duplicates
                bool hasDuplicates = request.PostDetail.GroupBy(obj => obj.Address).Any(group => group.Count() > 1);
                if (hasDuplicates)
                {
                    var duplicates = request.PostDetail
                                    .GroupBy(obj => obj.Address)
                                    .Where(group => group.Count() > 1)
                                    .SelectMany(group => group.Select((item, index) => new { Item = item, Index = index }));

                    foreach (var duplicate in duplicates)
                    {
                        int index = duplicate.Index; // Vị trí (chỉ mục) của đối tượng trùng lặp
                        var duplicateItem = duplicate.Item; // Đối tượng trùng lặp

                        // Thêm thông báo lỗi cho đối tượng trùng lặp tại vị trí (chỉ mục) index
                        ModelState.AddModelError($"PostDetail[{index}].Address", "Bạn không được đánh giá liên tục 1 địa điểm");
                       
                    }
                    return View(request);
                }              
            }

            // Lấy danh mục
            request.CategoryPostDetail = new List<Category>();

            foreach (var categoryName in selectedCategories)
            {
                var category = new Category { Name = categoryName , CategoriesId = 0 };
                request.CategoryPostDetail.Add(category);
            }

            // Chỉ lấy tối đa 5 danh mục
            if (request.CategoryPostDetail.Count > 5)
            {
                List<Category> firstThreeCategories = request.CategoryPostDetail.Take(5).ToList();
                request.CategoryPostDetail = firstThreeCategories;
            }

            //// Chỉ lấy tối đa 5 ảnh
            foreach (var item in request.PostDetail)
            {
                if (item.GetImage != null && item.GetImage.Count > 5)
                {
                    List<IFormFile> img_list = item.GetImage.Take(5).ToList();
                    item.GetImage = img_list;
                }
            }

            //request.CategoryPostDetail = categoryPostDetail;
            request.numberLocation = new TakeNumberLocation();

            request.PostId = 0;
            request.UserId = User.Identity.Name;

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _postApiClient.CreateOrUpdatePost(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm bài đánh giá thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditPost(int id)
        {
            var result = await _postApiClient.GetById(id);

            if (result.IsSuccessed)
            {
                return View(
                result.ResultObj
            );
            }
            return RedirectToAction("Error", "Index");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> EditPost(PostCreateRequest request, [FromForm(Name = "SelectedCategories")] string[] selectedCategories)
        {
            // Lấy danh mục
            request.CategoryPostDetail = new List<Category>();
            foreach (var categoryName in selectedCategories)
            {
                var category = new Category { Name = categoryName, CategoriesId = 0 };
                request.CategoryPostDetail.Add(category);
            }

            //request.CategoryPostDetail = categoryPostDetail;
            request.numberLocation = new TakeNumberLocation();


            var result = await _postApiClient.CreateOrUpdatePost(request);
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
    }
}
