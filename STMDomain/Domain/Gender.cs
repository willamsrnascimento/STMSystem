namespace STMDomain.Domain
{
    public class Gender : Entity
    {
        public string Description { get; set; }
        public virtual IEnumerable<PersonalData> PersonalDatas { get; set; }
    }
}