using EStore.WPF.Models;
using System.Windows;

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
