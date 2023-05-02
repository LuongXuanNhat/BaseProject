using BaseProject.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Image
    {
        public int Image_id { get; set; }
        public int Post_id { get; set; }
        public string Name { get; set; }
        public int Numerical_order { get; set; }


        // Relationship
        public Post Post { get; set; }
    }
}
