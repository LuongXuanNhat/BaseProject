using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.System.Users
{
    public class FollowerVm
    {

        [Display(Name = "Tên tài khoản")]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string? Image { get; set; }
    }
}
