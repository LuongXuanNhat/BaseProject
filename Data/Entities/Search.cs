namespace Data.Entities
{
    public class Search
    {
        public string Search_id { get; set; }
        public string User_id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }


        // Relationship
        public User User { get; set; }
    }
}
