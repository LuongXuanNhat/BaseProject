namespace BaseProject.Data.Entities
{
    public class CategoriesDetail
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CategoriesId { get; set; }
        public string Description { get; set; }


        // RelationShip
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}
