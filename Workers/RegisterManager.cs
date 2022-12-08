using AlienAccounting.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlienAccounting.Workers
{

    internal static class RegDataContainer
    {
        internal static readonly AlienDataWorker data_worker = new AlienDataWorker();
        internal static string Login { get; set; }
        internal static string Password { get; set; }
        internal static string Conf_password { get; set; }
    }
    internal class RegisterManager
    {
        

         
        public RegisterManager(string login, string password, string confirmed_password)
        {

            RegDataContainer.Login = login;
            RegDataContainer.Password = password;
            RegDataContainer.Conf_password = confirmed_password;
            
        }
        public void Register()
        {   
            Debug.WriteLine("Register+");
            User user_obj = new User();
            user_obj.login = RegDataContainer.Login;
            user_obj.password = RegDataContainer.Password;

            RegDataContainer.data_worker.Add_User_data(user_obj);


            foreach (User elem in RegDataContainer.data_worker.UserSet.ToList())
            {
                Debug.WriteLine("please check data");
                Debug.WriteLine(elem.login, " and ", elem.password);
            };


        }


        
    }
    
    public  class ErorManager
    {   

        public  string ErorHandler(string login, string password, string confirmed_password)
        {
            Debug.WriteLine("check succes");
            if (Check_passsword(password, confirmed_password) == null)
            {
                Debug.WriteLine(password + " " + confirmed_password);
                return "ConfPassError";
            }
            else
            {
                Debug.WriteLine(password + " " + confirmed_password+"11");
                if (Check_UserDs(login) == null)
                {
                    return "LoginExistEror";
                }
                else
                {
                    return "Ok";
                }
            }
        }
        private string Check_passsword(string password, string confirmed_password)
        {
            Debug.WriteLine("check succes");
            if (String.Compare(password,confirmed_password)==0)
            {
                return "confirmed";
            }
            else
            {
                Debug.WriteLine(password+" "+ confirmed_password);
                return null;
            }

        }

        private  string Check_UserDs(string login)
        {
            Debug.WriteLine("login eror");
            return RegDataContainer.data_worker.By_login(login).login;
        }

    }
}
