using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using System.Text.Json.Serialization;

namespace BaseProject.Data.Entities
{
    public class NoticeDetail
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public YesNo IsRead { get; set; }


        // Relationship
        public Notification? Notification { get; set; }
        public AppUser? User { get; set; }
    }
}
