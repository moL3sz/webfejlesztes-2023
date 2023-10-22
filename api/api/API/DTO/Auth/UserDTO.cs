namespace api.API.DTO.Auth {

    public class UserDTO
    {
        /// <summary>
        /// Felhasználó email címe
        /// </summary>

        public required string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public required string Name {  get; set; }


    }
}
