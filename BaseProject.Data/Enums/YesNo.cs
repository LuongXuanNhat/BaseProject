using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Enums
{
    public enum YesNo
    {
        [Display(Name = "Đã đánh giá")]
        yes = 0,
        [Display(Name = "Chưa đánh giá")]
        no = 1
    }
}
