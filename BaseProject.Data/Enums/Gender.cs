using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Enums
{
    public enum Gender
    {
        [Display(Name = "Nam")]
        Nam = 0,
        [Display(Name = "Nữ")]
        Nữ =  1,
        [Display(Name = "Không")]
        Không = 2
    }
}
