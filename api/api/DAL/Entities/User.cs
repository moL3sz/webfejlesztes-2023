﻿using Microsoft.AspNetCore.Identity;

namespace api.DAL.Entities
{
    public class User : IdentityUser
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public long? 
    }
}
