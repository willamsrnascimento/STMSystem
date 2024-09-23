namespace STMComunication.Dtos.Login
{
    public record LoginRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            return !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password));
        }
    }
}
