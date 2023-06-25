using BaseProject.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseProject.Data.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UploadDate { get; set; }
        public int View { get; set; }
        public int Like { get; set; }
        public Guid UserId { get; set; }
        public YesNo Check { get; set; }



        // relationship
        public AppUser User { get; set; }
        public List<CategoriesDetail> CategoriesDetail { get; set; }
        public List<LocationsDetail> LocationsDetail { get; set; }
        public List<Comment> Comment { get; set; }
        public List<Report> Report { get; set; }
        public List<Share> Share { get; set; }
        public List<Like> Likess { get; set; }
        public List<Video> Video { get; set; }


        // Constructor

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
            this.View = obj.View;
            this.UploadDate = DateTime.Now;
            this.UserId = obj.UserId;
            this.Title = obj.Title;
        }

        public Post()
        {

        }
    }
}
