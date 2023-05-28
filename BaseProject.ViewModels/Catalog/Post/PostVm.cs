using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Post
{
    public class PostVm
    {
        public int PostId { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int View { get; set; }

    }
}
