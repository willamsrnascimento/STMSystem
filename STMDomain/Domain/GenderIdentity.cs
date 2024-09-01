namespace STMDomain.Domain
{
    public class GenderIdentity : Entity
    {
        public string Description { get; set; }
        public IEnumerable<PersonalData> PersonalDatas { get; set; }
    }
}