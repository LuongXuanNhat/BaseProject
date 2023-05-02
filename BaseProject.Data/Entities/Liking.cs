using BaseProject.Data.Entities;

namespace BaseProject.Data.Entities
{
    public class Liking
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Guid UserId { get; set; }
        public int CommentId { get; set; }
        public DateTime Date { get; set; }



        // Relationship
        public Post Post { get; set; }
        public AppUser User { get; set; }
        public Comment Comment { get; set; }
    }
}
