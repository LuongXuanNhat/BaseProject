namespace Data.Entities
{
    public class Location
    {
        public string Location_id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }


        // relationship
        public List<LocationsDetail> LocationsDetail{ get; set; }
    }
}
