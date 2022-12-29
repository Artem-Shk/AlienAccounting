using AlienAccounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml;

namespace AlienAccounting.Workers
{
    internal class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
    public abstract class DbControllerSoul
    {
        private string _cnn = "Data Source=(localdb)\\MSSQLLocalDB;" +
                          "Initial Catalog=AlienDB" +
                          ";Integrated Security=True;" +
                          "Connect Timeout=3";

        internal List<Object[]> TakeData(string field_name = "*", string table_name = "UserSet")
        {
            Debug.WriteLine("abstract is a life");
            List<Object[]> rows = new List<Object[]>();

            using (SqlConnection con = new SqlConnection(_cnn))
            {

                con.Open();
                SqlDataReader dbTables = new SqlCommand($"SELECT {field_name}  FROM {table_name}", con).ExecuteReader();


                while (dbTables.Read())
                {
                    Object[] values = new Object[dbTables.FieldCount];
                    int instances = dbTables.GetValues(values);
                    rows.Add(values);
                }
                if (rows.Count < 0) { return null; }
                con.Close();
            };
            return rows;

        }
        /// <summary>
        /// Dont forget in list elements set a child class this shit makes new row in yor db
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="table_name"></param>
        /// <returns></returns>

        internal string SetData(List<SuperModel> rows, string table_name)
        {
            using (SqlConnection con = new SqlConnection(_cnn))
            {

                con.Open();
                foreach (SuperModel row in rows)
                {
                    var Dict = row.ToDict();



                    string comand =
                    $"INSERT INTO {table_name}" +
                    $" ({string.Join(",", Dict.Select(x => x.Key))}) " +
                    $"VALUES ({string.Join(",", Dict.Select(x => x.Value is int ? x.Value.ToString() : $"'{x.Value.ToString()}'"))})";


                    var dbTables = new SqlCommand(comand, con).ExecuteNonQuery();
                }
                con.Close();
                return "fuck ya";
            };




        }
    }
    public class DBController : DbControllerSoul
    {

        

        public DBController()
        {
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

        public List<User> takeUsers()
        {
            List<User> users = new List<User>();
            foreach (object[] item in base.TakeData("*", "UserSet"))
            {

                User User = new User(item[1] as string,
                                    item[2] as string,
                                    item[3] as string);
                users.Add(User);

            }
            return users;
        }
        public List<string> takeLoginUsers()
        {
            List<string> users = new List<string>();
            foreach (object[] item in TakeData("login", "UserSet"))
            {
                users.Add(item[0] as string);
                Debug.WriteLine(item[0]);
            }

            return users;
        }
        public List<BodyPart> takeBodyParts()
        {
            List<BodyPart> BodyParts = new List<BodyPart>();
            foreach (object[] item in base.TakeData("*", "BodyPartsSet"))
            {
                BodyPart bodypart = new BodyPart(item[1] as string,
                                                (int)item[2]);

                BodyParts.Add(bodypart);
            }
            return BodyParts;
        }
        public string SetsUserData(User data)
        {
            //TODO fix first parametr
            return base.SetData(new List<SuperModel>() { data }, "UserSet");
        }

    }

   public class DataContext 
   {
        private readonly DBController Controller = new DBController();
        public List<User> Users { get { return Controller.takeUsers(); }}
        public List<BodyPart> BodyParts { get {return Controller.takeBodyParts();}  }
    }
   internal class UiConroller:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private RelayCommand _viewSubrows;
        public RelayCommand ViewSubrows
        {
            get {
                return _viewSubrows = (new RelayCommand(s => { OnPropertyChanged(); } )); 
            }
        }
        
        
        
        
        
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
