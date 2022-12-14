using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AlienAccounting.Models
{
    public class User:SuperModel
    {

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(string login = null, string password = null, string email = null)
        {
            Login = login;
            Password = password;
            Email = email;
        }
        /// <summary>
        /// returns dict with key like params and values of object 
        /// 
        /// </summary>
        /// <returns>Dictionary<string,Object></string,object> </returns>
        public override Dictionary<string,object> ToDict()
        {
            return new Dictionary<string, object>()
            {
                {"Login",this.Login},
                {"Password",this.Password},
                {"Email",this.Email},
            };
        }
     

    }
}
