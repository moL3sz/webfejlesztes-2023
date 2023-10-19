namespace api.API.DTO.Auth {


    /// <summary>
    /// Bejelentkező felhasználó
    /// </summary>
    public class LoginUserDTO {

        /// <summary>
        /// Felhasználó email címe
        /// </summary>
        public required string Email { get; set; }


        /// <summary>
        /// Jelszó
        /// </summary>
        public required string Password { get; set; }
    }
}
