using EStore.WPF.Models;
using EStore.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
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
   
    public partial class ProductPage : Page
    {
        private readonly RepositoryManager _repo;
        private readonly Staff _staff;
        private Product _selectedProduct;
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
                _selectedProduct = selectedProduct; 
                productIdTextBox.Text = selectedProduct.ProductId.ToString();
                categoryComboBox.SelectedValue = selectedProduct.Category.CategoryId; 
                productNameTextBox.Text = selectedProduct.ProductName;
                unitPriceTextBox.Text = selectedProduct.UnitPrice.ToString(); 
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddProductPage(_repo));
        }
    
    private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct != null)
            {
                _selectedProduct.ProductName = productNameTextBox.Text;

                // Parse UnitPrice từ TextBox và check invalid input
                if (int.TryParse(unitPriceTextBox.Text, out int unitPrice))
                {
                    _selectedProduct.UnitPrice = unitPrice;
                }
                else
                {
                    MessageBox.Show("Invalid unit price format. Please enter a valid integer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _selectedProduct.Category = (Category)categoryComboBox.SelectedItem;

                int result = _repo.ProductRepository.Update(_selectedProduct);
                if (result > 0)
                {
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadProducts(); //Load lại Product
                }
                else
                {
                    MessageBox.Show("Failed to update product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (productListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select one or more products to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the selected product(s)?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                foreach (Product selectedProduct in productListView.SelectedItems)
                {
                    int deleteResult = _repo.ProductRepository.Delete(selectedProduct.ProductId);
                    if (deleteResult > 0)
                    {
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                // Sau khi xóa xong, làm mới danh sách sản phẩm
                LoadProducts();
            }
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchTextBox.Text;

            // Gọi phương thức tìm kiếm và cập nhật danh sách sản phẩm hiển thị
            var filteredProducts = _repo.ProductRepository.SearchByName(searchText);
            productListView.ItemsSource = filteredProducts;
        }
    }
}
