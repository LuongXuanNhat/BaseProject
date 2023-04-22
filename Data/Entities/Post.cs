namespace Data.Entities
{
    public class Post
    {
        public string Post_id { get; set; }
        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public int View { get; set; }
        public Guid User_id { get; set; }



        // relationship
        public User User { get; set; }
    }
}
