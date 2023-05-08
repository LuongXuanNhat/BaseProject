using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class LocationsDetail
    {
        public LocationsDetail(int locationId, int postId, string title, DateTime when, GoWith goWith, string content)
        {
            LocationId = locationId;
            PostId = postId;
            Title = title;
            When = when;
            GoWith = goWith;
            Content = content;
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime When { get; set; }
        public GoWith GoWith { get; set; }
        public string Content { get; set; }


        // Relationship
        public Post Post { get; set; }
        public Location Location { get; set; }
    }
}
