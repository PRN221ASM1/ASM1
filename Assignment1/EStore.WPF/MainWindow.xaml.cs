
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
using EStore.WPF.Models;
using EStore.WPF.Pages;
using EStore.WPF.Repositories;
using EStore.WPF.Windows;
namespace EStore.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RepositoryManager repositoryManager;
        private readonly NavigationService _navigationService;
        private readonly Staff _staff;
        public MainWindow(Staff staff)
        {
            InitializeComponent();
            _staff = staff;
            foreach (MenuItem item in mainMenu.Items)
            {
                item.Click += menuItem_click;
            }
            btnLogout.Click += btnLogout_lick;
            repositoryManager = new RepositoryManager();
            _navigationService = new NavigationService(repositoryManager,staff);
            setControl();
            this.WindowState = WindowState.Maximized;
        }
        private void setControl()
        {
            foreach (MenuItem item in mainMenu.Items)
            {
                if (item.Name == "Staff")
                {
                    item.Header = $"Staff({_staff.Name})";
                }
            }
        }
        public void menuItem_click(Object sender, RoutedEventArgs e)
        {
            var item = (MenuItem)sender;
            if (item != null)
            {
                if (item.Name == "Product")
                {
                    frameMain.Content = _navigationService.GetPage("Product");
                }
                else if(item.Name == "Report")
                {
                    frameMain.Content = _navigationService.GetPage("Report");
                }
                else if (item.Name == "Order")
                {
                    frameMain.Content = _navigationService.GetPage("Order");
                }
                else if (item.Name == "Staff")
                {
                    frameMain.Content = _navigationService.GetPage("Staff");
                }
            }
        }
        public void btnLogout_lick(object sender,RoutedEventArgs e)
        {
            if (_staff != null)
            {

                Window Login = new Login();
                Login.Show();
                this.Close();
            }
        }

    }
}
