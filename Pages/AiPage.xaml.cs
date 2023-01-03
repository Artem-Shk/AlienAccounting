
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AlienAccounting.Workers.CvWorkers;

namespace AlienAccounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для AiPage.xaml
    /// </summary>
    public partial class AiPage : Page 
    {
        public AiPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new CvWorker().RunTest();
        }
    }
    
}
