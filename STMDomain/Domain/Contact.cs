namespace STMDomain.Domain
{
    public class Contact : Entity
    {
        public string PhoneNumber { get; set; }
        public bool IsWhatsappConfirmed { get; set; }
        public string Email { get; set; }
        public PersonalData PersonalData { get; set; }
    }
}