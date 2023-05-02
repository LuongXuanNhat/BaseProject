using BaseProject.Data.Entities;

namespace BaseProject.Data.Entities
{
    public class Category
    {
        public int Categories_id { get; set; }
        public string Name { get; set; }

        public List<CategoriesDetail> CategoriesDetail { get; set; }

    }
}
