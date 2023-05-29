using BaseProject.Data.Entities;

namespace BaseProject.Data.Entities
{
    public class Category
    {
        public int CategoriesId { get; set; }
        public string Name { get; set; }


        // Relationship
        public List<CategoriesDetail>? CategoriesDetail { get; set; }
        public List<CategoriesLocation>? CategoriesLocation { get; set; }

    }
}
