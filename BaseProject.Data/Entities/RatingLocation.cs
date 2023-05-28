using BaseProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class RatingLocation
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int LocationDetailId { get; set; }
        public Guid UserId { get; set; }
        public int? Stars { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        public YesNo Check { get; set; }



        // Relationship

        public Location Location { get; set; }
        public AppUser User { get; set; }

    }
}
