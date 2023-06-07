using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Comments
{
    public class CommentPageViewModel
    {
        public CommentCreateRequest Comment { get; set; }
        public List<CommentCreateRequest> CommentList { get; set; }
    }
}
