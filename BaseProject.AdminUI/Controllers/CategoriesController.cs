using BaseProject.ApiIntegration;
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

            //var request = new GetUserPagingRequest()
            //{
            //    Keyword = keyword,
            //    PageIndex = pageIndex,
            //    PageSize = pageSize
            //};
            //var data = await _categoryApiClient.GetPagings(request);
            //ViewBag.Keyword = keyword;

            //var categories = await _categoryApiClient.GetAll(languageId);
            //ViewBag.Categories = categories.Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString(),
            //    Selected = categoryId.HasValue && categoryId.Value == x.Id
            //});

            //if (TempData["result"] != null)
            //{
            //    ViewBag.SuccessMsg = TempData["result"];
            //}
            //return View(data);
            return View();
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
            if (result.IsSuccessed != null)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                //return RedirectToAction("Index");
                return View();
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }

        //[HttpGet]
        //public async Task<IActionResult> CategoryAssign(int id)
        //{
        //    var roleAssignRequest = await GetCategoryAssignRequest(id);
        //    return View(roleAssignRequest);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    var result = await _productApiClient.CategoryAssign(request.Id, request);

        //    if (result.IsSuccessed)
        //    {
        //        TempData["result"] = "Cập nhật danh mục thành công";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", result.Message);
        //    var roleAssignRequest = await GetCategoryAssignRequest(request.Id);

        //    return View(roleAssignRequest);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

        //    var product = await _productApiClient.GetById(id, languageId);
        //    var editVm = new ProductUpdateRequest()
        //    {
        //        Id = product.Id,
        //        Description = product.Description,
        //        Details = product.Details,
        //        Name = product.Name,
        //        SeoAlias = product.SeoAlias,
        //        SeoDescription = product.SeoDescription,
        //        SeoTitle = product.SeoTitle
        //    };
        //    return View(editVm);
        //}

        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public async Task<IActionResult> Edit([FromForm] ProductUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View(request);

        //    var result = await _productApiClient.UpdateProduct(request);
        //    if (result)
        //    {
        //        TempData["result"] = "Cập nhật sản phẩm thành công";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");
        //    return View(request);
        //}

        //private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int id)
        //{
        //    var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

        //    var productObj = await _productApiClient.GetById(id, languageId);
        //    var categories = await _categoryApiClient.GetAll(languageId);
        //    var categoryAssignRequest = new CategoryAssignRequest();
        //    foreach (var role in categories)
        //    {
        //        categoryAssignRequest.Categories.Add(new SelectItem()
        //        {
        //            Id = role.Id.ToString(),
        //            Name = role.Name,
        //            Selected = productObj.Categories.Contains(role.Name)
        //        });
        //    }
        //    return categoryAssignRequest;
        //}

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    return View(new ProductDeleteRequest()
        //    {
        //        Id = id
        //    });
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(ProductDeleteRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    var result = await _productApiClient.DeleteProduct(request.Id);
        //    if (result)
        //    {
        //        TempData["result"] = "Xóa sản phẩm thành công";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Xóa không thành công");
        //    return View(request);
        //}
    }
}
