using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using BaseProject.ViewModels.System.Users;
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
        public int PostId { get; set; }
        public string? UserId { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [MaxLength(100)]
        [Display(Name = "Tiêu đề bài đánh giá")]
        public string Title{ get; set; }

        public TakeNumberLocation? numberLocation { get; set; }

        // Relationship
        public List<PostDetailRequest> PostDetail { get; set; }

        // Contrustor
        public PostCreateRequest(int postId, string? userId, string title, List<PostDetailRequest> postDetail)
        {
            PostId = postId;
            UserId = userId;
            Title = title;
            PostDetail = postDetail;
        }

        public PostCreateRequest(PostCreateRequest post)
        {
            PostId = post.PostId;
            UserId = post.UserId;
            Title = post.Title;
            PostDetail = post.PostDetail;
        }

        public PostCreateRequest()
        {  

        }

    }
}
