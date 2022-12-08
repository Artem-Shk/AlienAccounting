using AlienAccounting.Workers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace AlienAccounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            var s = new CheckModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegisterManager registerManager = new RegisterManager();
            string password = registerManager.Check_passsword(this.Confirm_password.Text, this.Password.Text);
            if (password != null ) {

                //Debug.WriteLine("Clean Data " + this.Login.Text);
                
                registerManager.Register(this.Login.Text, password);
                this.NavigationService.Navigate(new WelcomePage());
                    }
            
        }
    }
}
