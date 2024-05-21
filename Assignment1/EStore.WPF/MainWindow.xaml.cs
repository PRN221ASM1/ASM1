
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
using EStore.WPF.Services;
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
        private int _pageActive = 0;
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
            _navigationService = new NavigationService(repositoryManager, staff);
            this.Loaded += Load;
        }
        private void setControl()
        {
            // staff
            if (_staff.Role == 1)
            {
                foreach (MenuItem item in mainMenu.Items)
                {
                    if (item.Name == "Order" || item.Name == "Staff" || item.Name == "Report")
                    {
                        item.IsEnabled = true;
                        item.Visibility = Visibility.Visible;
                    }
                    else if (item.Name == "Product") 
                    {
                        item.Visibility = Visibility.Collapsed; 
                    }
                    else
                    {
                        item.IsEnabled = false;
                        item.Visibility = Visibility.Collapsed;
                    }
                }

                foreach (MenuItem item in mainMenu.Items)
                {
                    if (item.Name == "Staff")
                    {
                        item.Header = $"Profile";
                    }
                }
            }
            // admin
            // admin
            else if (_staff.Role == 0)
            {
                foreach (MenuItem item in mainMenu.Items)
                {
                    if (item.Name == "Order") // If the menu item is "Order"
                    {
                        item.Visibility = Visibility.Collapsed; // Hide it for admin users
                    }
                    else
                    {
                        item.IsEnabled = true;
                        item.Visibility = Visibility.Visible;
                    }
                }

                // Show the admin profile menu item
                AdminProfilePage.Visibility = Visibility.Visible;

                foreach (MenuItem item in mainMenu.Items)
                {
                    if (item.Name == "Staff")
                    {
                        item.Header = $"Staff";
                    }
                }
            }

        }

        public void AdminProfilePage_Click(Object sender, RoutedEventArgs e)
        {
            // Open the admin profile page
            frameMain.Content = _navigationService.GetPage("AdminProfilePage");
        }


        public void menuItem_click(Object sender, RoutedEventArgs e)
        {
            var item = (MenuItem)sender;
            _pageActive = mainMenu.Items.IndexOf(sender);
            if (item != null)
            {
                var page = item.Name switch
                {
                    "Product" => _navigationService.GetPage("Product"),
                    "Report" => _navigationService.GetPage("Report"),
                    "Order" => _navigationService.GetPage("Order"),
                    "Staff" => _navigationService.GetPage("Staff"),
                    "AdminProfilePage" => _navigationService.GetPage("AdminProfilePage"), 
                    _ => null
                };
                if (page != null)
                {
                    frameMain.Content = page;
                    PageActive();
                }
            }
        }


        private void Load(object sender,RoutedEventArgs e)
        {
            setControl();
            PageActive();
            frameMain.Content = _navigationService.GetPage("Product");

        }
        private void PageActive()
        {
            for (int i = 0; i < mainMenu.Items.Count; i++)
            {
                MenuItem menuItem = mainMenu.Items[i] as MenuItem;
                if (menuItem != null)
                {
                    menuItem.Foreground = (_pageActive == i) ? Brushes.Red : Brushes.Black;
                }
            }
        }


        public void btnLogout_lick(object sender, RoutedEventArgs e)
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
