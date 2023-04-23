using Data.Enum;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string User_id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        //   public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBir { get; set; }
        public string Address { get; set; }



        // relationship
        public List<CategoriesDetail> CategoriesDetail { get; set; }
        public List<LocationsDetail> LocationsDetail { get; set; }
        public List<Rating> Rating { get; set; }
        public List<Liking> Liking { get; set; }
        public List<Comment> Comment { get; set; }
        public List<Report> Report { get; set; }
        public List<Share> Share { get; set; }
        public List<Saved> Saved { get; set; }
        public List<Search> Search { get; set; }
        public List<NoticeDetail> NoticeDetail { get; set; }
        public List<Following> Follower { get; set; }
        public List<Following> Followee { get; set; }
        

    }
}
