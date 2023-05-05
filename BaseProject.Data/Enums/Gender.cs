using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Enums
{
    public enum Gender
    {
        [Display(Name = "Giới tính")]
        Nam,
        Nữ,
        Không
    }
}
