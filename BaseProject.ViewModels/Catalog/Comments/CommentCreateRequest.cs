using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string UserName { get; set; }
        public int? PreCommentId { get; set; }

        [StringLength(2000)]
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
