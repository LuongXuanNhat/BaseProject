namespace Data.Entities
{
    public class NoticeDetail
    {
        public string Id { get; set; }
        public string Notification_id { get; set; }
        public string User_id { get; set; }
        public string Content { get; set; }


        // Relationship
        public Notification Notification { get; set; }
        public User User { get; set; }
    }
}
