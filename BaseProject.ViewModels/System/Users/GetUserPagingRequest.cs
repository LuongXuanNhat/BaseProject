using BaseProject.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
        public string? UserName { get; set;}
        public string? ProvinceName { get; set;}
    }
}
