using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Comments
{
    public class ChatQA
    {
        public int? QuestionId { get; set; }
        public int LocationId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
    }
}
