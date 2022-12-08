using AlienAccounting.Workers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlienAccounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {   
        private bool IsEror = true;
        private ErorManager erorHandler = new ErorManager();
        private string password  { get;
                                                }
        public AuthPage()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsEror == false) 
            {
                Debug.WriteLine("Button_Click+");
                RegisterManager registerManager = new RegisterManager(this.Login.Text, this.Password.Text, this.Confirm_password.Text);
                
                registerManager.Register();
                this.NavigationService.Navigate(new WelcomePage());
            }
            
                
           
           ;
        }



        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            if (!String.IsNullOrWhiteSpace(this.Login.Text))
            {
                Debug.WriteLine("Login_TextChanged+");
                if (erorHandler.ErorHandler(this.Login.Text, this.Password.Text, this.Confirm_password.Text) == "LoginExistEror")
                {
                    Debug.WriteLine("Log_error+");
                    this.Login.BorderBrush = Brushes.Red;
                    this.ErorText.Text = "Login is already exist";
                    IsEror = true;
                }
                else
                {
                    this.Login.BorderBrush = Brushes.Lime;
                    this.ErorText.Text = "";
                    IsEror = false;
                }
            }
                
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("password_TextChanged");
            if (erorHandler.ErorHandler(this.Login.Text, this.Password.Text, this.Confirm_password.Text) == "LoginExistEror")
            {
                Debug.WriteLine("Pass errore");
                this.Confirm_password.BorderBrush = Brushes.Red;
                this.ErorText.Text = "Password is not same";
                IsEror = true;
            }
            else
            {
                this.Confirm_password.BorderBrush = Brushes.Lime;
                this.ErorText.Text = "";
                IsEror = false;
            }
        }

        private void Confirm_password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("Confirm_password_LostFocus+");
            if (erorHandler.ErorHandler(this.Login.Text, this.Password.Text, this.Confirm_password.Text) == "LoginExistEror")
            {
                Debug.WriteLine("pass eror");
                this.Confirm_password.BorderBrush = Brushes.Red;
                this.ErorText.Text = "Password is not same";
                IsEror = true;
            }
            else
            {
                this.Confirm_password.BorderBrush = Brushes.Lime;
                this.ErorText.Text = "";
                IsEror = false;
            }
        }
    }
}


