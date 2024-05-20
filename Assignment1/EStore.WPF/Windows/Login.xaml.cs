using EStore.WPF.Models;
using EStore.WPF.Services;
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
    public partial class Login : Window
    {
        private readonly LoginService _loginService;

        public Login()
        {
            InitializeComponent();
            _loginService = new LoginService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var password = txtPassword.Password;

            Staff authenticatedStaff = _loginService.Authenticate(name, password);

            if (authenticatedStaff != null)
            {
                var mainWindow = new MainWindow(authenticatedStaff);
                mainWindow.WindowState = WindowState.Maximized;
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid name or password.");
            }
        }


    }

}
