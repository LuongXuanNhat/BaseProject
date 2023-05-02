using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Search
    {
        public int Search_id { get; set; }
        public Guid User_id { get; set; }
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        // Relationship
        public User User { get; set; }
    }
}
