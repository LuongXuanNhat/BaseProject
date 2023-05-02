namespace BaseProject.Data.Entities
{
    public class Following
    {
        public Guid Follower_id { get; set; }
        public Guid Followee_id { get; set; }
        public DateTime Date { get; set; }



        // Relationship
        public User Follower { get; set; }
        public User Followee { get; set; }
    }
}
