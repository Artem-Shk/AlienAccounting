using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienAccounting.Models
{
    public class BodyPart:SuperModel
    {
        public string Name {get;set;}
        public int UserId { get;set;}
        public BodyPart(string name = null, int user_id = -1) {
            Name = name;
            UserId = user_id;
        }
        public override Dictionary<string,object> ToDict()
        {
            return new Dictionary<string, object>()
            {
                {"Name",this.Name},
                {"UserId",this.UserId},
            };
        }
    }
}
