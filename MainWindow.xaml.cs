using AlienAccounting.Workers.tests;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace AlienAccounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //TestDbController.tableNameChekr();
            //TestDbController.CheckSetUsers();
            //TestDbController.ChecksetData();
            //TestDbController.CheckUserLogs();
            InitializeComponent();

            main_frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            

        }
        

    }
} 