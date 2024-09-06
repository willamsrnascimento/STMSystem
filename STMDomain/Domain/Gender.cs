namespace STMDomain.Domain
{
    public class Gender : Entity
    {
        public string Description { get; set; }
        public IEnumerable<PersonalData> PersonalDatas { get; set; }
    }
}