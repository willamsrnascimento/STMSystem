using STMDomain.Enums;
using System.ComponentModel.DataAnnotations;

namespace STMDomain.Domain
{
    public abstract class Entity
    {
        public long Id { get; set; }

        [StringLength(60)]
        public string CreatedBy { get; set; }    
        public DateTime CreatedOn { get; set; }

        [StringLength(60)]
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long StatusId { get; set; }
        public virtual Status Status { get; set; }

        public Entity()
        {
            CreatedOn = DateTime.UtcNow;
            StatusId = (long) StatusEnum.Active; 

        }
    }
}
