namespace Data.Entities
{
    public class Liking
    {
        public int Id { get; set; }
        public int Post_id { get; set; }
        public Guid User_id { get; set; }
        public int Comment_id { get; set; }
        public DateTime Date { get; set; }



        // Relationship
        public Post Post { get; set; }
        public User User { get; set; }
        public Comment Comment { get; set; }
    }
}
