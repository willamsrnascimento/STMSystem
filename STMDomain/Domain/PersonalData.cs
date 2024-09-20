using STMDomain.Enums;

namespace STMDomain.Domain
{
    public class PersonalData : Entity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int Age { get; set; }
        public string Occupancy { get; set; }
        public long? EducationId { get; set; }
        public virtual Education? Education { get; set; }
        public long? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
        public long? SexualOrientationId { get; set; }
        public virtual SexualOrientation? SexualOrientation { get; set; }
        public long? MaritalStatusId { get; set; }
        public virtual MaritalStatus? MaritalStatus { get; set; }
        public string? ResponsibleCpf { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<SocialBenefits> SocialBenefits { get; set; }
        public long AddressId { get; set; }
        public virtual Address Address { get; set; }
        public long? FamilyDataId { get; set; }
        public virtual FamilyData? FamilyData { get; set; }

        public void SetCreatedBy(string id)
        {
            CreatedBy = id;
            Address.CreatedBy = id;

            if(FamilyData != null)
            {
                FamilyData.CreatedBy = id;
            }

            foreach (var item in Contacts)
            {
                item.CreatedBy = id;               
            }
        }
        
        public void SetUpdateddByAndUpdatedOn (string id)
        {
            UpdatedBy = id;
            UpdatedOn = DateTime.UtcNow;
        }
    }
}
