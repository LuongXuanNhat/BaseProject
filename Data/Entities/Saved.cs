namespace Data.Entities
{
    public class Saved
    {
        public string Id { get; set; }
        public string Post_id { get; set; }
        public string User_id { get; set; }
        public DateTime Date { get; set; }



        // Relationship
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
