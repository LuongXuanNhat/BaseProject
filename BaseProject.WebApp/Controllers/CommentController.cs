using BaseProject.ApiIntegration.Comment;
using BaseProject.ViewModels.Catalog.Comments;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetComments(int postId)
        {
            var comments = await _commentApiClient.GetById(postId);
            return PartialView("/Views/Posts/_CommentList.cshtml", comments);
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
