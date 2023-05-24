using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using BaseProject.ViewModels.Catalog.Comments;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Post
{
    public class PostDetailRequest
    {
        public int postDetailId { get; set; }
        [Required]
        [Display(Name = "Tên địa điểm")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Viết đánh giá")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        [StringLength(500) ]
        public string Content { get; set; }
        public int? ViewCount { get; set; }
        public int? LikeCount { get; set; }
        public int? ShareCount { get; set; }
        public int? SaveCount { get; set; }

        
        [Display(Name = "Bạn đi vào thời gian nào?")]
        [Required(ErrorMessage = "Bạn cần nhập thời gian đến địa chỉ này")]
        [DisplayFormat(DataFormatString = "{0:MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime When { get; set; }

        [Display(Name = "Thêm ảnh")]
        public List<IFormFile>? GetImage { get; set; }

        public List<string>? ImageList { get; set; }
        public List<CommentCreateRequest>? CommentList { get; set; }


        // Relationship
        //public PostCreateRequest Post { get; set; }
        //public Location Location { get; set; }


    }
}
