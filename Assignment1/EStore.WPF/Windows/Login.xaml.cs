using EStore.WPF.Models;
using Microsoft.Extensions.Configuration;
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

namespace EStore.WPF.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly Account account;
        public Login()
        {
            InitializeComponent();
            btnLoign.Click += btnLogin_click;
        }
        
        private void btnLogin_click(object sebder,RoutedEventArgs e)
        {
            Staff user = loginUser();
            if (user == null)
            {
                Window main = new MainWindow(user);
                main.Show();
                this.Close();
            }
            
        }
        private Staff loginUser()
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;
        
        return null;
    }
    }
}
