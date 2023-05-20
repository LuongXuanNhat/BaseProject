using BaseProject.Application.Catalog.Posts;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Location;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {

            var products = await _postService.GetPostPagingUser(request);
            return Ok(products);
        }

        // https://localhost:7202/posts/create
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] PostCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            var result = await _postService.Create(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _postService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _postService.GetById(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var username = await _postService.Delete(id);

            if (username == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpGet]
        public async Task<ApiResult<PostCreateRequest>> LoadPost()
        {
            return new ApiSuccessResult<PostCreateRequest>();
        }

        [AllowAnonymous]
        [HttpGet("locations")]
        public async Task<IActionResult> SearchLocations(string searchText)
        {
            // Truy vấn dữ liệu từ cơ sở dữ liệu dựa trên từ khóa tìm kiếm
            var results = await _postService.GetAll(searchText);
            List<SearchPlaceVm> placeList = new List<SearchPlaceVm>();
            for (int i = 0; i < results.Count; i++)
            {
                SearchPlaceVm place = new SearchPlaceVm(); // Khởi tạo đối tượng SearchPlaceVm
                place.LocationId = results[i].LocationId;
                place.Name = results[i].Name;
                place.Address = results[i].Address;

                placeList.Add(place);
            }

            return Ok(placeList);
        }
    }
}
