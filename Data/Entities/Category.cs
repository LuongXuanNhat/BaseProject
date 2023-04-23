namespace Data.Entities
{
    public class Category
    {
        public string Categories_id { get; set; }
        public string Name { get; set; }

        public List<CategoriesDetail> CategoriesDetail { get; set; }

    }
}
