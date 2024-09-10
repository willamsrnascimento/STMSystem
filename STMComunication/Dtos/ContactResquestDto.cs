namespace STMComunication.Dtos
{
    public record ContactResquestDto
    {
        public string PhoneNumber { get; set; }
        public bool IsWhatsappConfirmed { get; set; }
        public string Email { get; set; }
    }
}