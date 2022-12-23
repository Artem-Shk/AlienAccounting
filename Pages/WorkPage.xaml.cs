using AlienAccounting.Models;
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
using static AlienAccounting.Workers.DbControllerSoul;

namespace AlienAccounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkPage.xaml
    /// </summary>
    public partial class WorkPage : Page
    {

        public DBController dBController
        {
            get; set;
        } = new DBController();


    

    

        public WorkPage()
        {
            
            InitializeComponent();
            this.DataContext = new DBController();

        }
    }
}
