using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Location
{
    public class LocationCreateRequest
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; }
        public List<string>? ImageList { get; set; }
        public List<IFormFile>? GetImage { get; set; }
    }
}
