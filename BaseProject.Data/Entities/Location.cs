namespace BaseProject.Data.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }


        // relationship
        public List<LocationsDetail> LocationsDetail{ get; set; }
    }
}
