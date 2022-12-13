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
    internal class AlienDataWorker: DataModelContainer
    {
       
        
        public int Add_User_data(User user)
        {  
                    UserSet.Add(user);
                    try
                    {
                        SaveChanges();
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
             
            return -1;
        }
        /// <summary>
        /// takes data from database by login
        /// </summary>
        /// <param name="login"></param>
        /// <returns >return  row with login< or null/returns>
        public User By_login(string login)
        {
            Debug.WriteLine("by login +");
            return UserSet.FirstOrDefault(c=>c.login==login);
        }
        public  List<User> TakeAllUsers()
        {
            
            return UserSet.ToList();
        }
        }
}
