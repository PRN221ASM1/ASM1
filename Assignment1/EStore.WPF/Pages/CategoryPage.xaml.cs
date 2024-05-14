using EStore.Core.repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EStore.WPF.Pages
{
    /// <summary>
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryPage(ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            _categoryRepository = categoryRepository;
            this.Loaded += Load;
            btnSave.Click += btnSave_click;
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            var categories = _categoryRepository.FindAll();
            if (categories != null)
            {
                categoryListView.ItemsSource = categories;
            }
        }
        private void btnSave_click(object sender,RoutedEventArgs e)
        {

        }
    }
}
