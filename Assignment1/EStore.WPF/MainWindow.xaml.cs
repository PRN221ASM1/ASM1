
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
namespace EStore.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyStoreContext _context;
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IStaffRepository staffRepository;
        private readonly NavigationService _navigationService;

        public MainWindow()
        {
            InitializeComponent();
            foreach (MenuItem item in mainMenu.Items)
            {
                item.Click += menuItem_click;
            }
            _context = new MyStoreContext();
            productRepository = new ProductRepository(_context);
            categoryRepository = new CategoryRepository(_context);
            orderRepository = new OrderRepository(_context);
            staffRepository = new StaffRepository(_context);
            _navigationService = new NavigationService(productRepository, categoryRepository, orderRepository, staffRepository);
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
                else if(item.Name == "Category")
                {
                    frameMain.Content = _navigationService.GetPage("Category");
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

    }
}
