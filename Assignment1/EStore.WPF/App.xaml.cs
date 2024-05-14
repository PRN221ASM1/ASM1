using Autofac;
using EStore.Core.connection;
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
            using (var context = new EStoreContext())
            {
                context.Database.EnsureCreated();
            }
        }

    }
}
