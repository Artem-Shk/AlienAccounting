using AlienAccounting.Workers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace AlienAccounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {   

        private AuthHandler _authHandler = new AuthHandler();
        private DBController _dataContext = new DBController();
        public MainWindow parent { get {
                return (MainWindow)Window.GetWindow(this);
            } set { } }
       
        public AuthPage()
        {
            ShowsNavigationUI = false;
            InitializeComponent();
            

        }

        private void Login_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBlock = sender as TextBox; 
            if(_authHandler.logins.Contains(textBlock.Text))
            {
                
                this.ErorText.Text = "Change login";
            }
            else
            {
                this.ErorText.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _dataContext.SetsUserData(new Models.User(this.Login.Text, this.Password.Text,""));
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.Password.Text == this.Confirm_password.Text)
            {
                this.ErorText.Text = "";
            }
            else
            {
                this.ErorText.Text = "password shit";
            }
        }
    }
}


