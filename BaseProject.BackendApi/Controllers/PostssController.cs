using BaseProject.Application.Catalog.Posts;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostssController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostssController(IPostService postService)
        {
            _postService = postService;
        }

    



        // https://localhost:7202/posts/create

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create( PostCreateRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId = await _postService.Create(request);
            if (!categoryId.IsSuccessed)
                return BadRequest(categoryId);

            return Ok(categoryId);
        }
    }
}
