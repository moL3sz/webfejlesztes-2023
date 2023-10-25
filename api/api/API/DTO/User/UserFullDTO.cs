﻿namespace api.API.DTO.User {
    public class UserFullDTO {
        public required string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public required string UserName { get; set; }

        public Boolean EmailConfirmed { get; set; }
    }
}
