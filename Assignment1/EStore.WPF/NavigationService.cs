using EStore.WPF.Repositories;
using EStore.WPF.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EStore.WPF
{
    public class NavigationService
    {
        private readonly Dictionary<string, Page> _pages = new Dictionary<string, Page>();
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IStaffRepository _staffRepository;

        public NavigationService(IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, IStaffRepository staffRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _staffRepository = staffRepository;
        }

        public Page GetPage(string name)
        {
            if (_pages.ContainsKey(name))
            {
                return _pages[name];
            }

            Page page;
            switch (name)
            {
                case "Product":
                    page = new ProductPage(_productRepository);
                    break;
                case "Category":
                    page = new CategoryPage(_categoryRepository);
                    break;
                case "Order":
                    page = new OrderPage(_orderRepository);
                    break;
                case "Staff":
                    page = new StaffPage(_staffRepository);
                    break;
                default:
                    throw new ArgumentException($"Page with name '{name}' not found.");
            }
            _pages[name] = page;
            return page;
        }
    }

}
