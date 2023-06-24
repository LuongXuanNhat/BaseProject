namespace BaseProject.Data.Entities
{
    public class Following
    {
        //Người được theo dõi
        public Guid FollowerId { get; set; }

        //Người theo dõi
        public Guid FolloweeId { get; set; }
        public DateTime? Date { get; set; }



        // Relationship
        public AppUser Follower { get; set; }
        public AppUser Followee { get; set; }
    }
}
