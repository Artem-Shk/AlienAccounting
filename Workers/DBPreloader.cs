using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAccounting.Workers
{
    internal class DBPreloader
    {
        public static DataModelContainer DbContext = new DataModelContainer();
    }
}
