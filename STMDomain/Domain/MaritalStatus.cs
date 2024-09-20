namespace STMDomain.Domain
{
    public class MaritalStatus : Entity
    {
        public string Description { get; set; }
        public virtual IEnumerable<PersonalData> PersonalDatas { get; set; }
    }
}