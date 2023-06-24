using BaseProject.Application.Catalog.Posts;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.FavoriteSave;
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

        // Lấy tất cả bài viết
        [HttpGet("pagingall")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPostPaging([FromQuery] GetUserPagingRequest request)
        {

            var products = await _postService.GetPostPaging(request);
            return Ok(products);
        }
        
        // Lấy tất cả bài viết
        [HttpGet("pagingallfollow")]
        public async Task<IActionResult> GetAllFollowPostPaging([FromQuery] GetUserPagingRequest request)
        {

            var products = await _postService.GetPostFollowPaging(request);
            return Ok(products);
        }
        // Lấy tất cả bài viết - Admin
        [HttpGet("pagingalladmin")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPostPagingAdmin([FromQuery] GetUserPagingRequest request)
        {

            var products = await _postService.GetPostPagingAdmin(request);
            return Ok(products);
        }

        [HttpGet("check")]
        public async Task<IActionResult> Check([FromQuery] AddSaveVm request)
        {
            var result = await _postService.Check(request.Username, request.Id);
            if (result != null)
            {
                return Ok();
            }

            return BadRequest();

        }

        // https://localhost:7202/posts/create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreatePost([FromForm] PostCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await _postService.CreateOrUpdate(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddressToArchive(AddSaveVm request)
        {
            if (request.number == 1)
            {
                var result = await _postService.Like(request);
                if (!result.IsSuccessed)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPost("enable")]
        public async Task<IActionResult> Enable(PostEnable request)
        {
            var result = await _postService.Enable(request);
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
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _postService.GetById(id);
            return Ok(user);
        }

        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetByIdAdmin(int id)
        {
            var user = await _postService.GetByIdAdmin(id);
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


        [AllowAnonymous]
        [HttpGet("locations")]
        public async Task<IActionResult> SearchLocations(string searchText)
        {
            // Truy vấn dữ liệu từ cơ sở dữ liệu dựa trên từ khóa tìm kiếm
            var results = await _postService.GetAll(searchText);
            

            return Ok(results);
        }

        [AllowAnonymous]
        [HttpGet("show/{quantity}")]
        public async Task<IActionResult> TakeByQuantity(int quantity)
        {
            var user = await _postService.TakeTopByQuantity(quantity);
            return Ok(user);
        }

        
    }
}
