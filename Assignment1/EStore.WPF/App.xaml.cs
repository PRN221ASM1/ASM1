
using EStore.WPF.Models;
using EStore.WPF.Windows;
using System.Windows;

namespace EStore.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Login login = new Login();
            login.Show();
        }

    }
}
