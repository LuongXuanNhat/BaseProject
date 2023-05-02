namespace BaseProject.Data.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }


        // relationship
        public List<LocationsDetail> LocationsDetail{ get; set; }
    }
}
