using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Search
    {
        public int SearchId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        // Relationship
        public AppUser User { get; set; }
    }
}
