using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Share
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Guid UserId { get; set; }
        public string Method { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }



        // Relationship
        public Post Post { get; set; }
        public AppUser User { get; set; }
    }
}
