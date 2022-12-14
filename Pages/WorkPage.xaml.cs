﻿using AlienAccounting.Workers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlienAccounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkPage.xaml
    /// </summary>
    public partial class WorkPage : Page
    {

        public List<User> UserData { get; set; }
        public WorkPage()
        {
            AlienDataWorker Workers = new AlienDataWorker();
            this.UserData = Workers.UserSet.ToList();

            InitializeComponent();
            userDataGrid.ItemsSource = UserData;
        }
    }
}