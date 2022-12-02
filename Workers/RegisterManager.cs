using System;
using System.Collections.Generic;
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
                return password;
            }
            return null;
        }
        public void Login(string login, string password)
        {   
            User user_obj = new User();
            user_obj.login = login;
            user_obj.password = password;
            data_worker.Add_data(user_obj);
        }
    }
}
