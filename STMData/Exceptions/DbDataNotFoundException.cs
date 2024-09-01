using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STMData.Exceptions
{
    public class DbDataNotFoundException : Exception
    {
        public DbDataNotFoundException(string message) : base(message)
        {

        }
    }
}
