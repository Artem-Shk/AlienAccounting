using AlienAccounting.Workers;
using Microsoft.Win32;
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
       
        public AuthPage()
        {
            InitializeComponent();
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (IsEror == false ) {
                RegisterManager register = new RegisterManager(this.Login.Text, this.Password.Text, this.Confirm_password.Text);
                register.Register();
                this.NavigationService.Navigate(new WelcomePage());
            }
            
                
           
           ;
        }



        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
           if(Login != null & ErorText != null)
            {
                if (!String.IsNullOrWhiteSpace(Login.Text))
                {
                    Debug.WriteLine("Login_TextChanged+");
                }
                    
                if (erorHandler.Check_UserDs(this.Login.Text) == "Login_same_eror")
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
            if (Password != null & ErorText != null)
            {
                if (erorHandler.Check_passsword(Password.Text, Confirm_password.Text) == "ConfPassError")
                {
                    Debug.WriteLine("Pass errore");
                    this.Password.BorderBrush = Brushes.Red;
                    this.ErorText.Text = "Password is not same";
                    IsEror = true;
                }
                else
                {
                    this.Password.BorderBrush = Brushes.Lime;
                    this.Confirm_password.BorderBrush = Brushes.Lime;
                    this.ErorText.Text = "";
                    IsEror = false;
                }
            }
                
        }

        private void Confirm_password_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("Confirm_password_LostFocus+");
            if (Confirm_password != null & ErorText != null)
            {
                if (erorHandler.Check_passsword(Password.Text, Confirm_password.Text) == "ConfPassError")
                {
                    Debug.WriteLine("pass eror");
                    this.Confirm_password.BorderBrush = Brushes.Red;
                    this.ErorText.Text = "Password is not same";
                    IsEror = true;
                }
                else
                {
                    this.Confirm_password.BorderBrush = Brushes.Lime;
                    this.Password.BorderBrush = Brushes.Lime;
                    this.ErorText.Text = "";
                    IsEror = false;
                }
            }
                
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


