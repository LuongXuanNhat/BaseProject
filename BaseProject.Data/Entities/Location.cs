using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public Location()
        {
        }

        public Location(string name, string address)
        {
            Name = name;
            Address = address;
        }


        // relationship
        public List<LocationsDetail>? LocationsDetail{ get; set; }
        public List<RatingLocation>? RatingLocation { get; set; }
        public List<Image>? Image { get; set; }

    }
}
