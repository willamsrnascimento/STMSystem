namespace STMDomain.Domain
{
    public class MaritalStatus : Entity
    {
        public string Description { get; set; }
        public IEnumerable<PersonalData> PersonalDatas { get; set; }
    }
}