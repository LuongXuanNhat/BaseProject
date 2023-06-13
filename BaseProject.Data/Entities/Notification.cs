using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace BaseProject.Data.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }


        // relationship
        [NotMapped]
        [AllowNull]
        public List<NoticeDetail>? NoticeDetail { get; set; }

    }
}
