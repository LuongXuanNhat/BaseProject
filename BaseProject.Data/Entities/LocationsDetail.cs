using BaseProject.Data.Entities;

namespace BaseProject.Data.Entities
{
    public class LocationsDetail
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


        // Relationship
        public Post Post { get; set; }
        public Location Location { get; set; }
    }
}
