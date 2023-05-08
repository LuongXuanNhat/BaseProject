using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Post
    {
        public Post(string title, Guid userId)
        {
            Title = title;
            UploadDate = DateTime.Now;
            View = 0;
            UserId = userId;
        }
        public Post(Post obj)
        {
            this.PostId = obj.PostId;
            this.View = 0;
            this.UserId = obj.UserId;
            this.Title = obj.Title;
        }

        public int PostId { get; set; }
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UploadDate { get; set; }
        public int View { get; set; }
        public Guid UserId { get; set; }



        // relationship
        public AppUser User { get; set; }
        public List<CategoriesDetail> CategoriesDetail { get; set; }
        public List<LocationsDetail> LocationsDetail { get; set; }
        public List<Rating> Rating { get; set; }
        public List<Liking> Liking { get; set; }
        public List<Comment> Comment { get; set; }
        public List<Report> Report { get; set; }
        public List<Share> Share { get; set; }
        public List<Saved> Saved { get; set; }
        public List<Image> Image { get; set; }
        public List<Video> Video { get; set; }

    }
}
