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
        private Staff _user;
        private readonly RepositoryManager repo;
        public Login()
        {
            InitializeComponent();
            btnLoign.Click += btnLogin_click;
            _user = new Staff();
            repo = new RepositoryManager();
            cobUser.SelectedIndex=0;
        }

        private void btnLogin_click(object sebder, RoutedEventArgs e)
        {
            if (loginUser())
            {
                Window main = new MainWindow(_user);
                
                main.Show();
                this.Close();
            }

        }
        private bool loginUser()
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            _user = repo.StaffRepository.FindById(1);
            _user.Role = 0;
            return true;
        }

        private void admin_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
