using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Post
{
    public class TakeNumberLocation
    {

        [Display(Name = "Số địa điểm đánh giá")]
        public int? numberOfPlaces { get; set; }


        public TakeNumberLocation() { 
            numberOfPlaces = 1;
        }


    }
}
