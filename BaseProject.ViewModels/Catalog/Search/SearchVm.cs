using BaseProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Search
{
    public class SearchVm
    {
      //  public int SearchId { get; set; }
        public Guid UserId { get; set; }
        public List<string> Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        // Constructor

        public SearchVm() { }

    }
}
