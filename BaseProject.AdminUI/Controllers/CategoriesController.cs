using BaseProject.ApiIntegration.Category;
using BaseProject.Application.Catalog;
using BaseProject.BackendApi.Utilities.Constants;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaseProject.AdminUI.Controllers
{
    public class CategoriesController : BaseController
    {
        //private readonly IConfiguration _configuration;
        private readonly ICategoryApiClient _categoryApiClient;

        public CategoriesController(
            ICategoryApiClient categoryApiClient)
        {
            //_configuration = configuration;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _categoryApiClient.GetUsersPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _categoryApiClient.RegisterCategory(request);
            if (result.IsSuccessed != null )
            {
                TempData["result"] = "Thêm mới danh mục thành công";
                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Thêm danh mục thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _categoryApiClient.GetById(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new CategoryRequest()
                {
                    CategoriesId = id,
                    Name = user.Name
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,CategoryRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _categoryApiClient.UpdateCategory(id,request);
            if (result.IsSuccessed != null)
            {
                TempData["result"] = "Cập nhập danh mục thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhập danh mục thất bại");
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int idCategory)
        {
            return View(new CategoryRequest()
            {
                CategoriesId = idCategory
            });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _categoryApiClient.DeleteCategory(request.CategoriesId);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa danh mục thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

    }
}
