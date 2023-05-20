using BaseProject.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Data.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public int? LocationsDetailId { get; set; }
        public int? LocationId { get; set; }
        public string? FileName { get; set; }
        public string Path { get; set; }


        // Relationship
        public LocationsDetail LocationsDetail { get; set; }
        public Location Location { get; set; }
    }
}
