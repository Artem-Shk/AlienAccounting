using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace AlienAccounting.Workers
{
    internal class AlienDataWorker
    {
        private static DataModelContainer _data_model = new DataModelContainer();
        
        public int Add_data(object data)
        {
           // Debug.WriteLine(data.GetType().ToString());
            
            switch (data.GetType().ToString())
            {
                case "AlienAccounting.User":
                    _data_model.UserSet.Add(data as User);
                    try
                    {
                        _data_model.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                    Debug.WriteLine(_data_model.GetValidationErrors());
                    Debug.WriteLine("Data Adding succes");
                    break;
                case "AlienAccounting.Role":
                    _data_model.UserSet.Add(data as User);
                    _data_model.SaveChanges();
                    Debug.WriteLine("Data Adding succes");
                    break;



            }
               
             
            return -1;
        }
        public List<User> Show_data(string dataset_name,string key = null, string keyValue = null)
        {
            if (dataset_name == null) { Debug.WriteLine("dataset name is null"); ; }
            if (keyValue == null)
            {
                Debug.WriteLine("keyValue is null");
                if (dataset_name == "User")
                {   
                    foreach(User user in _data_model.UserSet.ToList())
                    {
                        Debug.WriteLine(user.password);
                    }
                    Debug.WriteLine("Succes show process");
                    return _data_model.UserSet.ToList();
                }
            }
            Debug.WriteLine("eror");
            return null;
        }

        
        
        //private void switch_set(object data)
        //{
            
        //    switch (data.GetType().ToString())
        //    {
        //        case "User":

        //            _data_model.SaveChanges();

        //            return _data_model.UserSet;


        //    }
        //    return null;


        }
}
