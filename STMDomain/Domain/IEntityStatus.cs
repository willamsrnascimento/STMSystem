using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMDomain.Domain
{
    public interface IEntityStatus
    {
        public long StatusId { get; set; }
        public Status Status { get; set; }
    }
}
