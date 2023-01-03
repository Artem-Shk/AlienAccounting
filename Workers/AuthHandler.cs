using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAccounting.Workers
{
    internal class AuthHandler
    {
        public List<string> logins = new DBController().takeLoginUsers();
        void CheckLogin(string login)
        {
            logins.Contains(login);
        }
    }
}
