namespace STMDomain.Domain
{
    public class Education : Entity
    {
        public string Description { get; set; }
        public IEnumerable<PersonalData> PersonalDatas { get; set; }

    }
}