namespace STMDomain.Domain
{
    public class Address : Entity
    {
        public string CEP { get; set; }
        public string Place { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ResidenceTime { get; set; }
        public PersonalData PersonalData { get; set; }
    }
}