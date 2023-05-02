using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Video
    {
        public int VideoId { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public int NumericalOrder { get; set; }


        // Relationship
        public Post Post { get; set; }
    }
}
