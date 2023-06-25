using Azure.Core;
using BaseProject.Application.Catalog.Categories;
using BaseProject.Application.Catalog.Comments;
using BaseProject.ViewModels.Catalog.Categories;
using BaseProject.ViewModels.Catalog.Comments;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaseProject.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;


        public CommentsController(
            ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comments = await _commentService.GetById(id);
            return Ok(comments);
        }


        [HttpGet("add/{Id}")]
        public async Task<IActionResult> GetById2(int Id)
        {
            var comments = await _commentService.GetById2(Id);
            return Ok(comments);
        }
        [HttpPost("addchat/{Id}")]
        public async Task<IActionResult> GetByIdChatQA(int Id, GetUserPagingRequest request)
        {
            var comments = await _commentService.GetByIdChatQA(Id,  request);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId = await _commentService.Create(request);
            if (!categoryId.IsSuccessed)
                return BadRequest(categoryId);

            return Ok(categoryId);
        }

        [HttpPost("chat")]
        public async Task<IActionResult> AddChatQA(ChatQA request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId = await _commentService.CreateChatQA(request);
            if (!categoryId.IsSuccessed)
                return BadRequest(categoryId);

            return Ok(categoryId);
        }

        //PUT: http://localhost/api/categoriess/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CommentCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commentService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //Delete: http://localhost/api/categoriess/id
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete(int commentId)
        {
            var result = await _commentService.Delete(commentId);
            return Ok(result);
        }
    }
}
