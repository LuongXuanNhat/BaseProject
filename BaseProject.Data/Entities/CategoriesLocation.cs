namespace BaseProject.Data.Entities
{
    public class CategoriesLocation
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int CategoriesId { get; set; }
        public string Description { get; set; }


        // RelationShip
        public Location Location { get; set; }
        public Category Category { get; set; }
    }
}
