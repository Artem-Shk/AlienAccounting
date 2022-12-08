using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAccounting.Workers
{
    internal class RegisterManager
    {   
        private readonly AlienDataWorker data_worker = new AlienDataWorker();
        public string Check_passsword(string password, string confirmed_password)
        {
            if(password == confirmed_password)
            {
                Debug.WriteLine("Password confirmed");
                return password;
            }
            return null;
        }
        public void Register(string login, string password)
        {
            Debug.WriteLine("Register is start " + login +" " + password);
            User user_obj = new User();
            user_obj.login = login;
            user_obj.password = password;
            data_worker.Add_data(user_obj);
           

            foreach (User elem in data_worker.Show_data("User"))
            {
                Debug.WriteLine("please check data");
                Debug.WriteLine(elem.login,elem.password);
            };
            
        }
    }
}
