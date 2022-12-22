using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlienAccounting.Workers.DbControllerSoul;

namespace AlienAccounting.Workers.tests
{
    public class TestDbController
    {   
        private static List<string> tableNames = new List<string>() {
        "UserSet",
        "RoleSet",
        "GenderSet",
        "curencySet",
        "BodyPartsSet"
        };
        public static void tableNameChekr()
        {   
            int count = 0;
            DBController s = new DBController();
            foreach ( string name in tableNames)
            {
                if (s.take_tablename().Contains(name))
                {
                    count++;
                }
            }
            if (count == tableNames.Count)
            {
                Debug.WriteLine("table Names OK");
            }
           
            


        }
        public static void ChecksetData()
        {
            DBController s = new DBController();
            if (s.SetsData() == "fuck ya")
            {
                Debug.WriteLine("Good Set Data good");
            }
            else {
                Debug.WriteLine("you in setData shit Johnny");
            
            };
          

        }

        public static void CheckSetUsers()
        {
            DBController s = new DBController();
            s.takeUsers();

        }
    }
    
}
