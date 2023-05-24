using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Comments
{
    public class CommentCreateRequest
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public Guid UserId { get; set; }
        public int? PreCommentId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
