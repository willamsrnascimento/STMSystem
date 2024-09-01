namespace STMDomain.Domain
{
    public class SocialProgram : Entity
    {
        public string Description { get; set; }
        public string Detail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<PersonalData> PersonalDatas { get; set; }
    }
}