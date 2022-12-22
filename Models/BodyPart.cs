using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAccounting.Models
{
    internal class BodyPart:SuperModel
    {
        public string Name {get;set;}
        public int UserId { get;set;}
        public BodyPart(string name = null, int user_id = -1) {
            Name = name;
            UserId = user_id;
        }
        public List<object> ToList()
        {
            return base.ToList(new List<object>() { Name, UserId});
        }
    }
}
