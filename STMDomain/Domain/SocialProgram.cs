namespace STMDomain.Domain
{
    public class SocialProgram : Entity
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}