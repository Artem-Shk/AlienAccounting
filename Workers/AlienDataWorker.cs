using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAccounting.Workers
{
    internal class AlienDataWorker
    {
        private static DataModelContainer _data_model = new DataModelContainer();
        
        public int Add_data(object data)
        {
            switch (data.GetType().ToString())
            {
                case "User":
                    _data_model.UserSet.Add(data as User);
                    _data_model.SaveChanges();
                    break;
              

            }
               
                
            return -1;
        }
    }
}
