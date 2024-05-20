
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
                    if (item.Name == "Product" || item.Name == "Order" || item.Name == "Staff")
                    {
                        item.IsEnabled = true;
                    }
                    else
                    {
                        item.IsEnabled = false;
                    }
                }

                foreach (MenuItem item in mainMenu.Items)
                {
                    if (item.Name == "Staff")
                    {
                        item.Header = $"Staff({_staff.Name})";
                    }
                }
            }
            // admin
            else if (_staff.Role == 0)
            {
                foreach (MenuItem item in mainMenu.Items)
                {
                    item.IsEnabled = true;
                }

                foreach (MenuItem item in mainMenu.Items)
                {
                    if (item.Name == "Staff")
                    {
                        item.Header = $"Admin({_staff.Name})";
                    }
                }
            }
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
