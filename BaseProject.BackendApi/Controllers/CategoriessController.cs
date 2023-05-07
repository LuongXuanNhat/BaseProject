using BaseProject.Application.Catalog;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.System.Users;
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

        //PUT: http://localhost/api/categoriess/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _categoryService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //Delete: http://localhost/api/categoriess/id
        [HttpDelete("{idCategory}")]
        public async Task<IActionResult> Delete(int idCategory)
        {
            var result = await _categoryService.Delete(idCategory);
            return Ok(result);
        }

        //http://localhost/api/categoriess/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var products = await _categoryService.GetCategoryPaging(request);
            return Ok(products);
        }

        //http://localhost/api/categoriess/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _categoryService.GetById(id);
            return Ok(user);
        }
    }
}
