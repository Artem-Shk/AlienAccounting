using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Documents;
using System.Xml;

namespace AlienAccounting.Workers
{
    internal class DBController
    {
        DBController() {
            string _cnn = "Data Source=(localdb)\\MSSQLLocalDB;" +
                          "Initial Catalog=AlienDB" +
                          ";Integrated Security=True;" +
                          "Connect Timeout=3";
            List<String> tableNames = new List<String>();
            using (SqlConnection con = new SqlConnection(_cnn))
            {
                con.Open();
                
                SqlDataReader dbTables =  new SqlCommand("SELECT table_name FROM INFORMATION_SCHEMA.TABLES").ExecuteReader();
                while (dbTables.Read())
                {
                    tableNames.Add(dbTables[0].ToString());
                    Debug.WriteLine(dbTables[0]);
                   
                }
                

                con.Close();
            }
        }
       
    }
}
