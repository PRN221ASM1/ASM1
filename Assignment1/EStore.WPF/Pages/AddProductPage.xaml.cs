using EStore.WPF.Models;
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
    /// Interaction logic for AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        private readonly RepositoryManager _repo;
        private readonly Staff _staff;
        private Product _selectedProduct;
        public AddProductPage(RepositoryManager repo)
        {

            InitializeComponent();
            _repo = repo;
            LoadCategories();


        }
        private void LoadCategories()
        {
            var categories = _repo.CategoryRepository.FindAll();
            categoryComboBox.ItemsSource = categories;
            categoryComboBox.DisplayMemberPath = "CategoryName"; // Hiển thị tên danh mục
            categoryComboBox.SelectedValuePath = "CategoryId"; // Xác định giá trị của combobox
        }


        private void saveButton_Click(object sender, RoutedEventArgs e)
        {


            // Kiểm tra xem liệu các trường thông tin đã được nhập đầy đủ hay không
            if (string.IsNullOrWhiteSpace(productNameTextBox.Text) || string.IsNullOrWhiteSpace(unitPriceTextBox.Text))
            {
                MessageBox.Show("Product Name and Unit Price cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Dừng việc thêm sản phẩm nếu có lỗi
            }

            // Kiểm tra xem giá trị của Unit Price có phải là một số hợp lệ không
            if (!decimal.TryParse(unitPriceTextBox.Text, out decimal unitPrice))
            {
                MessageBox.Show("Unit Price must be a valid number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Dừng việc thêm sản phẩm nếu có lỗi
            }

            // Kiểm tra xem đã chọn một danh mục hay chưa
            if (categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a category!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Dừng việc thêm sản phẩm nếu có lỗi
            }

            // Lấy danh mục được chọn từ combobox
            var selectedCategory = (Category)categoryComboBox.SelectedItem;

            // Tạo đối tượng Product mới từ dữ liệu nhập vào
            var newProduct = new Product
            {
                ProductName = productNameTextBox.Text,
                Category = selectedCategory,
                UnitPrice = (int)unitPrice
            };

            // Hiển thị hộp thoại xác nhận trước khi thêm sản phẩm
            MessageBoxResult result = MessageBox.Show("Are you sure you want to add this product?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Nếu người dùng chọn Yes, thêm sản phẩm vào cơ sở dữ liệu
            if (result == MessageBoxResult.Yes)
            {
                int addResult = _repo.ProductRepository.Add(newProduct);
                if (addResult > 0)
                {
                    MessageBox.Show("Product added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService?.Navigate(new ProductPage(_repo, null));
                }
                else
                {
                    MessageBox.Show("Failed to add product.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}