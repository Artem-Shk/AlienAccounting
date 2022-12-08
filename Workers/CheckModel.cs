using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlienAccounting.Workers
{
    public class CheckModel
    {
        public static List<String> SetNames;
       
        public CheckModel()
        {
            


            foreach (PropertyInfo item in typeof(DataModelContainer).GetProperties())
                {

                if (item.PropertyType.GetTypeInfo().IsGenericType)
                {
                    
                    Debug.WriteLine("types are taked" + item.PropertyType.GetTypeInfo().GenericTypeArguments[0].ToString());
                }
                



            }
        }

    }
}
