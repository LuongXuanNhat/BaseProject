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
using HtmlAgilityPack;
using BaseProject.ApiIntegration.Locations;
using BaseProject.ApiIntegration.Saves;
using BaseProject.ViewModels.Catalog.FavoriteSave;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BaseProject.WebApp.Controllers
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
        //private readonly UserManager<AppUser> _userManager;

        public PostsController(IConfiguration configuration, 
            IPostApiClient postApiClient, ICategoryApiClient cateApiClient,
            BaseApiClient baseApiClient, ILocationApiClient locationApiClient,
            ISaveApiClient saveApiClient )
        {
            _configuration = configuration;
            _postApiClient = postApiClient;
            _cateApiClient = cateApiClient;
            _baseApiClient = baseApiClient;
            _locationApiClient = locationApiClient;
            _saveApiClient = saveApiClient;

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
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
        public async Task<IActionResult> IndexAll(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            // Hàm để lấy danh sách địa điểm
            var LocationList = await _locationApiClient.TakeByQuantity(6);
            ViewData["ObjectList"] = LocationList;

            // Hàm để lấy danh sách bài đọc nhiều nhất
            var PostList = await _postApiClient.TakeTopByQuantity(5);
            ViewData["topList"] = PostList;

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
            foreach (var item in data.ResultObj.Items)
            {
                string editorContent = item.Content;
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(editorContent);

                // Loại bỏ các thẻ không mong muốn
                RemoveUnwantedTags(document.DocumentNode);

                // Lấy nội dung đã xử lý
                string sanitizedContent = document.DocumentNode.OuterHtml;

                if (sanitizedContent.Length > 200)
                {
                    item.Content = sanitizedContent.Substring(0, 200);
                }
                else
                {
                    item.Content = sanitizedContent;
                }

            }

            return View(data.ResultObj);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _postApiClient.GetById(id);

            var addPostSaveVm = new AddSaveVm();
            addPostSaveVm.Username = User.Identity.Name;
           
            addPostSaveVm.Id = id;
            addPostSaveVm.number = 2;
            var checkSave = await _saveApiClient.Check(addPostSaveVm);

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create(TakeNumberLocation numberLocation)
        {
                        
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


            //request.CategoryPostDetail = categoryPostDetail;
            request.numberLocation = new TakeNumberLocation();

            request.PostId = 0;
            request.UserId = User.Identity.Name;
            var category1 = await _cateApiClient.GetAll();
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    // In lỗi ra console hoặc log
                    Console.WriteLine(error.ErrorMessage);
                }
                request.CategoryPostDetail = category1.ResultObj;
                return View(request);
            }

            var result = await _postApiClient.CreateOrUpdatePost(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Thêm bài đánh giá thành công";
                return RedirectToAction("Index");
            }
            
            request.CategoryPostDetail =  category1.ResultObj;
            if (result.Message == null)
            {
                result.Message = "Nội dung bài viết không được quá dài! Bạn cần viết ngắn lại";
            }
            else
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
            if (result.Message == null)
            {
                result.Message = "Nội dung bài viết không được quá dài! Bạn cần viết ngắn lại";
            }else
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Like([FromBody] AddSaveVm model)
        {
            model.number = 1;
            var data = await _postApiClient.Like(model);
            if (data.IsSuccessed)
            {
                return Ok();
            }

            return BadRequest();
        }


        public async Task<IActionResult> SearchData()
        {
            List<Location> results =await _postApiClient.GetAll();
            return Json(results);
        }


        private void RemoveUnwantedTags(HtmlNode node)
        {
            if (node.NodeType == HtmlNodeType.Element)
            {
                // Danh sách các thẻ không mong muốn cần loại bỏ
                string[] unwantedTags = { "p", "a", "strong", "oembed", "span", "img" };

                if (node.Name == "figure")
                {
                    node.ParentNode.RemoveChild(node, true);
                    return;
                }
                else if (unwantedTags.Contains(node.Name))
                {
                    if (node.Name == "p" && node.ParentNode.Name == "figure")
                    {
                        node.Remove();
                    }
                    else if (node.Name == "strong" && node.ParentNode.Name == "p")
                    {
                        var strongContent = node.InnerHtml; // Lưu lại nội dung của thẻ strong
                        node.ParentNode.InsertBefore(HtmlNode.CreateNode(strongContent), node); // Thêm nội dung trước thẻ strong
                        node.Remove(); // Xóa thẻ strong
                    }
                    else if (node.Name == "img")
                    {
                        // Kiểm tra nội dung của thẻ img
                        if (string.IsNullOrWhiteSpace(node.InnerHtml))
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                    }
                    else
                    {
                        foreach (var childNode in node.ChildNodes.ToList())
                        {
                            RemoveUnwantedTags(childNode);
                        }
                    }
                    return;
                }
            }

            foreach (var childNode in node.ChildNodes.ToList())
            {
                RemoveUnwantedTags(childNode);
            }
        }






    }
}
