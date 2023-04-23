namespace Data.Entities
{
    public class Report
    {
        public string Id { get; set; }
        public string Post_id { get; set; }
        public string User_id { get; set; }
        public string AllegedUser_id { get; set; }
        public string Comment_id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }


        // Relationship
        public Post Post { get; set; }
        public User User { get; set; }
        public User AllegedUser { get; set; }
        public Comment Comment { get; set; }
    }
}
