using BaseProject.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public int NumericalOrder { get; set; }


        // Relationship
        public Post Post { get; set; }
    }
}
