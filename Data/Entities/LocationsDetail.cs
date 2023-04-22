namespace Data.Entities
{
    public class LocationsDetail
    {
        public string Id { get; set; }
        public string Location_id { get; set; }
        public string Post_id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


        // Relationship
        public Post Post { get; set; }
        public Location Location { get; set; }
    }
}
