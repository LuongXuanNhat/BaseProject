using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Categories
{
    public class CategoryRequest
    {
        [Display(Name = "Tên danh mục")]
        public string? Name { get; set; }
    }
}
