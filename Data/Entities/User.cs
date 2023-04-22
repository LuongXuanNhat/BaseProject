using Data.Enum;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string User_id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        //   public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBir { get; set; }
        public string Address { get; set; }

    }
}
