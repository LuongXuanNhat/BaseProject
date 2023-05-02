using BaseProject.Data.Entities;

namespace BaseProject.Data.Entities
{
    public class NoticeDetail
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }


        // Relationship
        public Notification Notification { get; set; }
        public AppUser User { get; set; }
    }
}
