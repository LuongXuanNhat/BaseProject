using BaseProject.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public int LocationsDetailId { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public int NumericalOrder { get; set; }


        // Relationship
        public LocationsDetail LocationsDetail { get; set; }
        public Location Location { get; set; }
    }
}
