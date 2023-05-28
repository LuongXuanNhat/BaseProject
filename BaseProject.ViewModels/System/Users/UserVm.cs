using BaseProject.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaseProject.ViewModels.System.Users
{
    public class UserVm
    {
        public Guid Id { get; set; }

        [Display(Name = "Họ và Tên")]
        public string Name { get; set; }

        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }
        
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Image { get; set; }
        [Display(Name = "Thêm ảnh đại diện")]
        [NotMapped]
        public IFormFile? GetImage { get; set; }

        [Display(Name = "Giới tính")]
        public Gender? Gender { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBir { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public IList<string> Roles { get; set; }

        // Thông số 
        public int? PostNumber { get; set; }
    }
}
