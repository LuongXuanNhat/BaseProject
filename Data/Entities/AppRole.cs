using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
