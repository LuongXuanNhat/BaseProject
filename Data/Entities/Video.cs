using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Video
    {
        public int Video_id { get; set; }
        public int Post_id { get; set; }
        public string Name { get; set; }
        public int Numerical_order { get; set; }


        // Relationship
        public Post Post { get; set; }
    }
}
