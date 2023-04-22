namespace Data.Entities
{
    public class Share
    {
        public string Id { get; set; }
        public string Post_id { get; set; }
        public string User_id { get; set; }
        public string Method { get; set; }
        public DateTime Date { get; set; }



        // Relationship
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
