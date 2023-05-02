using BaseProject.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Post
    {
        public int Post_id { get; set; }
        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public int View { get; set; }
        public Guid User_id { get; set; }



        // relationship
        public User User { get; set; }
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
