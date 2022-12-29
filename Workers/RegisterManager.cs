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
    
    
}
