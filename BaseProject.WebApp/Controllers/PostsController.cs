using BaseProject.ViewModels.Catalog.Post;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class PostsController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] PostCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            //var result = await _productApiClient.CreateProduct(request);
            //if (result)
            //{
            //    TempData["result"] = "Thêm mới sản phẩm thành công";
            //    return RedirectToAction("Index");
            //}

            //ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            //return View(request);
            return View();
        }
    }
}
