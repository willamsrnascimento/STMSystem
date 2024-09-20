namespace STMDomain.Domain
{
    public class SexualOrientation : Entity
    {
        public string Description { get; set; }
        public virtual IEnumerable<PersonalData> PersonalDatas { get; set; }
    }
}