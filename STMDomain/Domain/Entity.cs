namespace STMDomain.Domain
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }   
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long StatusId { get; set; }
        public Status Status { get; set; }

        public Entity()
        {
            CreatedOn = DateTime.Now;
        }
    }
}
