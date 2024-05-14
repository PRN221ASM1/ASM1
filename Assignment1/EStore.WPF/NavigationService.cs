using EStore.Core.repository;
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
        private readonly IMemberRepository _memberRepository;

        public NavigationService(IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, IMemberRepository memberRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _memberRepository = memberRepository;
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
                case "Member":
                    page = new MemberPage(_memberRepository);
                    break;
                default:
                    throw new ArgumentException($"Page with name '{name}' not found.");
            }
            _pages[name] = page;
            return page;
        }
    }

}
