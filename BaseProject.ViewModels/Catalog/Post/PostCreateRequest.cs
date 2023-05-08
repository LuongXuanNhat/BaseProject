using BaseProject.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Post
{
    public class PostCreateRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tiêu đề bài đánh giá")]
        public string Title{ get; set; }

        public TakeNumberLocation? numberLocation { get; set; }

        // Relationship
        public List<PostDetailRequest> PostDetail { get; set; }
    }
}
