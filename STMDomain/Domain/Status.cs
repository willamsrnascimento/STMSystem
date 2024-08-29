namespace STMDomain.Domain
{
    public class Status : Entity
    {
        public char StatusCode { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
    }
}