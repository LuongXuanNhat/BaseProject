﻿using Microsoft.AspNetCore.Identity;

namespace BaseProject.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
