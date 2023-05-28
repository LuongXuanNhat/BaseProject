using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Enums
{
    public enum YesNo
    {
        [Display(Name = "Chưa đánh giá")]
        no = 0,
        [Display(Name = "Đã đánh giá")]
        yes = 1
    }
}
