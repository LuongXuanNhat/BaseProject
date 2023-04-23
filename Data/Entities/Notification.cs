namespace Data.Entities
{
    public class Notification
    {
        public string Notification_id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }


        // relationship
        public List<NoticeDetail> NoticeDetail { get; set; }

    }
}
