using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Data.Entities
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string? Description { get; set; }
        public int? View { get; set; }
        
        [Required]
        [NotMapped]
        public List<IFormFile>? GetImage { get; set; }

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
     //   public List<Saved>? Saved{ get; set; }
        public List<RatingLocation>? RatingLocation { get; set; }
        public List<Image>? Image { get; set; }
        public List<CategoriesLocation>? CategoriesLocation { get; set; }

        
        [NotMapped]
        public List<QuestionAndAnswer> QuestionAndAnswers { get; set; }

    }
}
