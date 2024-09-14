namespace STMComunication.Dtos.PersonalData
{
    public record PersonalDataPostDto
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int Age { get; set; }
        public string Occupancy { get; set; }
        public long EducationId { get; set; }
        public long GenderId { get; set; }
        public long SexualOrientationId { get; set; }
        public long MaritalStatusId { get; set; }
        public string ResponsibleCpf { get; set; }
        public ICollection<ContactResquestDto> Contacts { get; set; }
        public ICollection<SocialBenefitsRequestDto> SocialBenefits { get; set; }
        public AddressRequestDto Address { get; set; }
        public FamilyDataRequestDto FamilyData { get; set; }
    }
}
