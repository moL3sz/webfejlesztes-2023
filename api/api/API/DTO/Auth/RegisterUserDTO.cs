namespace api.API.DTO.Auth {
    public class RegisterUserDTO {


        /// <summary>
        /// Felhasználó email címe
        /// </summary>
        public required string Email { get; set; }


        /// <summary>
        /// Vezetéknév
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Keresztnév
        /// </summary>
        public required string LastName { get; set; }


        /// <summary>
        /// Felhasználónév
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Teljes név
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";


        /// <summary>
        /// Jelszó
        /// </summary>
        public required string Password { get; set; }
    }
}
