﻿using BaseProject.Application.Catalog.Posts;
using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [AllowAnonymous]
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {

            var products = await _postService.GetPostPagingUser(request);
            return Ok(products);
        }

        // https://localhost:7202/posts/create
        [HttpPost]
        [AllowAnonymous]
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

    }
}
