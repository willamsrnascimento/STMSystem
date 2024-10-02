namespace STMComunication.Dtos.User
{
    public record UserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public string GetSimplifiedUserName()
        {
            return Email.Substring(0, Email.IndexOf("@"));
        }

    }
}
