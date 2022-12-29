using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace AlienAccounting.Workers.MVVMNavigation
{
    internal class Navigation
    {
        private static volatile Navigation instance;
        private static object syncRoot = new Object();

        private Navigation() { }

        private static Navigation Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Navigation();
                    }
                }

                return instance;
            }
        }
       
    }
}
