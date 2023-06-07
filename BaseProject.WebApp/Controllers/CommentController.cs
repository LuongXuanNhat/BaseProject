using BaseProject.ViewModels.Catalog.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    public class CommentController : Controller
    {
        // COMMENT

        private List<CommentCreateRequest> _comments;

        public CommentController()
        { 
            _comments = new List<CommentCreateRequest>();
        }

        [HttpPost]
        public IActionResult AddComment(int postId, string content)
        {
            var newComment = new CommentCreateRequest
            {
                Id = _comments.Count + 1,
                PostId = postId,
                UserId = Guid.NewGuid(),
                UserName = "User3",
                PreCommentId = null,
                Content = content,
                Date = DateTime.Now
            };

            _comments.Add(newComment);

            return PartialView("_Comment", newComment);
        }

        [HttpPost]
        public IActionResult Delete(int commentId)
        {
            var comment = _comments.Find(c => c.Id == commentId);
            if (comment != null)
            {
                _comments.Remove(comment);
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}
