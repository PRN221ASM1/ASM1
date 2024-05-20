
using EStore.WPF.Pages;
using System.Windows.Controls;
using EStore.WPF.Models;
using EStore.WPF.Repositories;

namespace EStore.WPF.Services
{
    public class NavigationService
    {
        private readonly Dictionary<string, Page> _pages = new Dictionary<string, Page>();
        private readonly RepositoryManager _repositoryManager;
        private readonly Staff _staff;
        public NavigationService(RepositoryManager repositoryManager, Staff staff)
        {
            _repositoryManager = repositoryManager;
            _staff = staff;
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
                    page = new ProductPage(_repositoryManager, _staff);
                    break;
                case "Report":
                    page = new ReportPage(_repositoryManager, _staff);
                    break;
                case "Order":
                    page = new OrderPage(_repositoryManager, _staff);
                    break;
                case "Staff":
                    page = new StaffPage(_repositoryManager, _staff);
                    break;
                default:
                    throw new ArgumentException($"Page with name '{name}' not found.");
            }
            _pages[name] = page;
            return page;
        }
    }

}
