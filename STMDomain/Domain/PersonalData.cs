namespace STMDomain.Domain
{
    public class PersonalData : Entity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int Age { get; set; }
        public string Occupancy { get; set; }
        public long EducationId { get; set; }
        public virtual Education Education { get; set; }
        public long GenderIdentityId { get; set; }
        public virtual GenderIdentity GenderIdentity { get; set; }
        public long SexualOrientationId { get; set; }
        public virtual SexualOrientation SexualOrientation { get; set; }
        public long MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public long ResponsibleId { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<SocialProgram> SocialPrograms { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }
        public long FamilyDataId { get; set; }
        public FamilyData FamilyData { get; set; }



    }
}
