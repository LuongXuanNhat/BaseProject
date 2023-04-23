namespace Data.Entities
{
    public class LocationsDetail
    {
        public int Id { get; set; }
        public int Location_id { get; set; }
        public int Post_id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


        // Relationship
        public Post Post { get; set; }
        public Location Location { get; set; }
    }
}
