namespace STMDomain.Domain
{
    public class Education : Entity
    {
        public string Description { get; set; }
        public virtual IEnumerable<PersonalData> PersonalDatas { get; set; }

    }
}