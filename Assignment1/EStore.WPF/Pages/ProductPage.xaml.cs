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

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productIdTextBox.Text = string.Empty;
            productNameTextBox.Text = string.Empty;
            unitPriceTextBox.Text = string.Empty;
            categoryComboBox.SelectedIndex = -1; // Đặt lại selectedIndex để xóa chọn mục trong combobox
            productListView.SelectedItem = null; // Xóa chọn hàng trong ListView
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra xem liệu các trường thông tin đã được nhập đầy đủ hay không
                if (string.IsNullOrWhiteSpace(productNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(unitPriceTextBox.Text) ||
                    categoryComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Dừng việc thêm sản phẩm nếu có lỗi
                }

                // Kiểm tra xem giá trị của Unit Price có phải là một số hợp lệ không
                if (!decimal.TryParse(unitPriceTextBox.Text, out decimal unitPrice))
                {
                    MessageBox.Show("Unit Price must be a valid number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Dừng việc thêm sản phẩm nếu có lỗi
                }

                // Tạo đối tượng Product mới từ dữ liệu nhập vào
                var newProduct = new Product
                {
                    ProductName = productNameTextBox.Text,
                    Category = (Category)categoryComboBox.SelectedItem,
                    UnitPrice = (int)unitPrice
                };

                // Thêm sản phẩm mới vào cơ sở dữ liệu
                int addResult = _repo.ProductRepository.Add(newProduct);
                if (addResult > 0)
                {
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Xóa nội dung của các TextBox và ComboBox sau khi thêm sản phẩm thành công
                    productNameTextBox.Text = string.Empty;
                    unitPriceTextBox.Text = string.Empty;
                    categoryComboBox.SelectedIndex = -1;

                    // Cập nhật danh sách sản phẩm trên trang ProductPage
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Failed to add product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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