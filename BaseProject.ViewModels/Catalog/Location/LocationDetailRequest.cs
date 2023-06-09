using BaseProject.ViewModels.Catalog.Post;
using BaseProject.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Location
{
    public class LocationDetailRequest
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int? View { get; set; }
        public int? RatingCount { get; set; }
        public double? RatingScore { get; set; }
        public int? ReviewPostCount { get; set; }
        public int? SaveCount { get; set; }
        public List<string> ImageList { get; set; }

        public PagedResult<PostDetailRequest> PagedPostResult { get; set; }

        
    }
}
