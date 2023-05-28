using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Enums
{
    public enum YesNo
    {
        [Display(Name = "Chưa đánh giá")]
        yes = 0,
        [Display(Name = "Đã đánh giá")]
        no = 1
    }
}
