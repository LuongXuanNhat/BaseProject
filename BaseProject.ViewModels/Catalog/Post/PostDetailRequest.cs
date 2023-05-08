using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
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
        public Guid IdUser { get; set; }

        [Display(Name = "Tên địa điểm")]
        public string Title { get; set; }

        [Display(Name = "Viết đánh giá")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        [StringLength(500) ]
        public string Content { get; set; }

        [Display(Name = "Bạn đi với ai?")]
        public GoWith GoWith { get; set; }

        [Display(Name = "Bạn đi vào thời gian nào?")]
        [DisplayFormat(DataFormatString = "{0:MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime When { get; set; }


        // Relationship
        public PostCreateRequest Post { get; set; }
        public Location Location { get; set; }
    }
}
