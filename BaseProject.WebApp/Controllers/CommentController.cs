using BaseProject.ApiIntegration.Comment;
using BaseProject.ViewModels.Catalog.Comments;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace BaseProject.WebApp.Controllers
{
    public class CommentController : Controller
    {
        // COMMENT

        private List<CommentCreateRequest> _comments;
        private readonly ICommentApiClient _commentApiClient;

        public CommentController(ICommentApiClient commentApiClient)
        { 
            _commentApiClient = commentApiClient;
            _comments = new List<CommentCreateRequest>();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int postId, string content)
        {
            if (User.Identity.Name == null)
            {
                return BadRequest();
            }
            var newComment = new CommentCreateRequest
            {
                //Id = _comments.Count + 1,
                PostId = postId,
                UserId = Guid.NewGuid(),
                UserName = User.Identity.Name,
                PreCommentId = null,
                Content = content,
                Date = DateTime.Now
            };
            var result = await _commentApiClient.AddComment(newComment);
            // var comments = await _commentApiClient.GetById(postId);
            if (result.IsSuccessed)
            {
                return Ok();
            }
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddChatQA([FromBody] ChatQA chatQA)
        {
            if (User.Identity.Name == null)
            {
                return BadRequest();
            }

            var result = await _commentApiClient.AddChatQA(chatQA);
            if (result.IsSuccessed)
            {
                return Ok();
            }
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> GetComments(int postId)
        {
            ViewBag.UserName = User.Identity?.Name;
            var comments = await _commentApiClient.GetById(postId);
            return PartialView("/Views/Posts/_CommentList.cshtml", comments);
        }

        [HttpPost]
        public async Task<IActionResult> GetChatQAs(int locationId, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetUserPagingRequest()
            {
                UserName = User.Identity.Name,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var comments = await _commentApiClient.GetByIdPlace(locationId, request);
            ViewBag.UserName = User.Identity.Name;
            ViewBag.PlaceId = locationId;
            return PartialView("/Views/Place/_PagedDiscuss.cshtml", comments);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int commentId)
        {
            var comments = await _commentApiClient.DeleteComment(commentId);
            if (comments.IsSuccessed)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

    }
}
