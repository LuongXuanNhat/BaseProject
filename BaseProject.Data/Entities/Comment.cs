using BaseProject.Data.Entities;

namespace BaseProject.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Guid UserId { get; set; }
        public int PreCommentId { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public DateTime Date { get; set; }


        // Relationship
        public Post Post { get; set; }
        public AppUser User { get; set; }
        public Comment PreComment { get; set; }
        public List<Report> Report { get; set; }
    }
}
