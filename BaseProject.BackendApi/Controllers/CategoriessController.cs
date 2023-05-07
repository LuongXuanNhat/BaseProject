using BaseProject.Application.Catalog;
using BaseProject.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriessController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriessController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromForm] CategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId = await _categoryService.Create(request);
            if (!categoryId.IsSuccessed)
                return BadRequest();

            return View(categoryId.Message);
        }

    }
}
