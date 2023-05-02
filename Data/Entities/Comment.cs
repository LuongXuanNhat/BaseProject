using BaseProject.Data.Entities;

namespace BaseProject.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int Post_id { get; set; }
        public Guid User_id { get; set; }
        public int PreComment_id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }


        // Relationship
        public Post Post { get; set; }
        public User User { get; set; }
        public Comment PreComment { get; set; }
        public List<Liking> Liking { get; set; }
        public List<Report> Report { get; set; }
    }
}
