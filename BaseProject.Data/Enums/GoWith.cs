using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Enums
{
    public enum GoWith
    {
        [Display(Name = "Đơn")]
        Solo = 0,
        [Display(Name = "Cặp đôi")]
        Couples = 1,
        [Display(Name = "Gia đình")]
        Family = 2,
        [Display(Name = "Bạn bè")]
        Friends = 3,
        [Display(Name = "Nhóm")]
        Group = 4
    }
}
