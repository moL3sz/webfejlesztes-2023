namespace api.API.DTO.Auth {

    /// <summary>
    /// A JWT-t ből jővő User kibontása ebbe Claimek alapján
    /// </summary>
    public class UserPrinciple {

        public required string Id { get; set; }

        public required string Name { get; set; }
        public required string Email { get; set; }

        public required IEnumerable<string> Roles { get; set;}

    }
}
