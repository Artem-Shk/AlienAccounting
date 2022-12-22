using AlienAccounting.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml;

namespace AlienAccounting.Workers
{
    public abstract class DbControllerSoul
    {
        private string _cnn = "Data Source=(localdb)\\MSSQLLocalDB;" +
                          "Initial Catalog=AlienDB" +
                          ";Integrated Security=True;" +
                          "Connect Timeout=3";
   
        private List<Object[]> TakeData(string field_name  = "*", string table_name = "UserSet")
        {
            Debug.WriteLine("abstract is a life");
            List<Object[]> rows = new List<Object[]>();
            
            using (SqlConnection con = new SqlConnection(_cnn))
            {

                con.Open();
                SqlDataReader dbTables = new SqlCommand(String.Format("SELECT "+ field_name + " FROM "+ table_name), con).ExecuteReader();
                
               
                while (dbTables.Read())
                {
                    Object[] values = new Object[dbTables.FieldCount];
                    int instances = dbTables.GetValues(values);
                    rows.Add(values);
                }
                if(rows.Count < 0) { return null; }
                con.Close();
            };
            return rows;

        }

        private string SetData(List<object> rows)
        {
            try{
                using (SqlConnection con = new SqlConnection(_cnn))
                {

                    con.Open();
                    foreach (object row in rows)
                    {

                    }
                    con.Close();
                };
                return "fuck ya";
            }
            catch
            {
                return "fuck";
            }
            
        }

        public class DBController: DbControllerSoul
        {
          
            public List<User> Users { get; set; }

            public DBController()
            {
                Users = takeUsers();
            }
            public List<string> take_tablename()
            {
                string _cnn = "Data Source=(localdb)\\MSSQLLocalDB;" +
                              "Initial Catalog=AlienDB" +
                              ";Integrated Security=True;" +
                              "Connect Timeout=3";
                List<String> tableNames = new List<String>();
                using (SqlConnection con = new SqlConnection(_cnn))
                {
                    con.Open();

                    SqlDataReader dbTables = new SqlCommand("SELECT table_name FROM INFORMATION_SCHEMA.TABLES", con).ExecuteReader();
                    while (dbTables.Read())
                    {
                        tableNames.Add(dbTables[0].ToString());
                        
                    }
                    con.Close();

                }
                return tableNames;
            }
            //public  List<string> TakeDataBodyParts()
            //{
            //    return base.TakeData("*", "BodyPartsSet");
            //}

            public List <User> takeUsers()
            {
                List<User> users = new List<User>();
                foreach (object[] item in TakeData("*", "UserSet"))
                {

                    User User= new User(item[1] as string,
                                        item[2] as string,
                                        item[3] as string);
                    users.Add(User);
                    
                }
                return users;
            }

            public string SetsData()
            {
               
               return base.SetData(new List<object>(){
                "ss",
                "1",
                1
                });

            }

        }
    }
}
