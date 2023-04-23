namespace Data.Entities
{
    public class CategoriesDetail
    {
        public int Id { get; set; }
        public int Post_id { get; set; }
        public int Categories_id { get; set; }
        public string Description { get; set; }


        // RelationShip
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}
