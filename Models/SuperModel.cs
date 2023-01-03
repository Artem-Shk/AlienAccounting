using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAccounting.Models
{
    public abstract class SuperModel
    {
        public virtual Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object>();
        }
    }
}
