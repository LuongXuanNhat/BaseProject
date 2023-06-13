using BaseProject.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Data.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public Guid UserId { get; set; }

        [NotMapped]
        public string? UserName { get; set; }
        public Guid? AllegedUserId { get; set; }
        public int? CommentId { get; set; }

        [MaxLength(1500)]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public YesNo IsRead { get; set; }


        // Relationship
        public Post? Post { get; set; }
        public AppUser? User { get; set; }
        public AppUser? AllegedUser { get; set; }
        public Comment? Comment { get; set; }
    }
}
