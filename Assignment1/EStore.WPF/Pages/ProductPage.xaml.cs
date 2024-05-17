using EStore.WPF.Models;
using EStore.WPF.Repositories;
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
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private readonly RepositoryManager _repo;
        private readonly Staff _staff;
        public ProductPage(RepositoryManager repo, Staff staff)
        {
            InitializeComponent();
            _repo = repo;
            _staff = staff;
            LoadProducts();
            LoadCategories();
        }
        private void LoadCategories()
        {
            var categories = _repo.CategoryRepository.FindAll();
            categoryComboBox.ItemsSource = categories;
        }

        private void LoadProducts()
        {
            var products = _repo.ProductRepository.FindAll();
            productListView.ItemsSource = products;
        }
        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productListView.SelectedItem is Product selectedProduct)
            {
                productIdTextBox.Text = selectedProduct.ProductId.ToString();
                categoryComboBox.SelectedItem = selectedProduct.Category; 
                productNameTextBox.Text = selectedProduct.ProductName;
                unitPriceTextBox.Text = selectedProduct.UnitPrice.ToString("F2"); 
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
