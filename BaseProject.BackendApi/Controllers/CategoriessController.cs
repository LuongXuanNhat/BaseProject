using BaseProject.Application.Catalog;
using BaseProject.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.BackendApi.Controllers
{
    // api/categoriess
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriessController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        
        public CategoriessController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        // https://localhost:7203/categories/create
        [HttpPost]
        public async Task<IActionResult> Create( CategoryRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId = await _categoryService.Create(request);
            if (!categoryId.IsSuccessed)
                return BadRequest(categoryId);

            return Ok(categoryId);
        }

    }
}
