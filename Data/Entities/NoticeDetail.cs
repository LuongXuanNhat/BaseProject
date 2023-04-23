namespace Data.Entities
{
    public class NoticeDetail
    {
        public int Id { get; set; }
        public int Notification_id { get; set; }
        public Guid User_id { get; set; }
        public string Content { get; set; }


        // Relationship
        public Notification Notification { get; set; }
        public User User { get; set; }
    }
}
