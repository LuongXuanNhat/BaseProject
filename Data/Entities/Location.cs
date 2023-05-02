namespace BaseProject.Data.Entities
{
    public class Location
    {
        public int Location_id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }


        // relationship
        public List<LocationsDetail> LocationsDetail{ get; set; }
    }
}
