namespace Data.Entities
{
    public class Comment
    {
        public string Id { get; set; }
        public string Post_id { get; set; }
        public string User_id { get; set; }
        public string PreComment_id { get; set; }
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
