using System.ComponentModel.DataAnnotations;

namespace STMDomain.Domain
{
    public abstract class Entity
    {
        public long Id { get; set; }

        [StringLength(15)]
        public string CreatedBy { get; set; }   
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(15)]
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
