using BaseProject.Application.Catalog.Categories;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Common;
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


        // https://localhost:7203/categories/create
        [HttpPost]
        public async Task<IActionResult> CreateCategory( CategoryRequest request)
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
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryRequest request)
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
        public async Task<IActionResult> DeleteCategory(int idCategory)
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

        [AllowAnonymous]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var cate = await _categoryService.GetAll();
            return Ok(cate);
        }
    }
}
