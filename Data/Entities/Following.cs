namespace Data.Entities
{
    public class Following
    {
        public string Id { get; set; }
        public string Follower_id { get; set; }
        public string Followee_id { get; set; }
        public DateTime Date { get; set; }



        // Relationship
        public User Follower { get; set; }
        public User Followee { get; set; }
    }
}
