using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }


        // relationship
        public List<NoticeDetail> NoticeDetail { get; set; }

    }
}
