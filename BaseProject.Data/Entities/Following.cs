namespace BaseProject.Data.Entities
{
    public class Following
    {
        public Guid FollowerId { get; set; }
        public Guid FolloweeId { get; set; }
        public DateTime Date { get; set; }



        // Relationship
        public AppUser Follower { get; set; }
        public AppUser Followee { get; set; }
    }
}
