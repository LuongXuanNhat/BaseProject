using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Location
{
    public class LocationVm
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? View { get; set; }
        public string? ImageList { get; set; }
    }
}
