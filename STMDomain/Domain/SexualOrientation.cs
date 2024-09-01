namespace STMDomain.Domain
{
    public class SexualOrientation : Entity
    {
        public string Description { get; set; }
        public IEnumerable<PersonalData> PersonalDatas { get; set; }
    }
}