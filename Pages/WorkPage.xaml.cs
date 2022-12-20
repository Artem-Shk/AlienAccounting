using AlienAccounting.Workers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlienAccounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkPage.xaml
    /// </summary>
    public partial class WorkPage : Page
    {

        AlienDataWorker Workers = new AlienDataWorker();
        public WorkPage()
        {
            List<User> UserData = Workers.UserSet.ToList();
            
            
            InitializeComponent();
            userDataGrid.ItemsSource = UserData;
            Workers.UserSet.Load();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Workers.SaveChanges();
            
        }
    }
}
