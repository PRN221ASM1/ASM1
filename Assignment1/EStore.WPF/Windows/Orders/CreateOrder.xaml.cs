using EStore.WPF.Models;
using EStore.WPF.Pages;
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

namespace EStore.WPF.Windows.Orders
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        private readonly RepositoryManager _repo;
        private readonly Staff _staff;
        private readonly List<OrderDetail> orderDetails;
        public CreateOrder(RepositoryManager repo,Staff staff)
        {
            InitializeComponent();
            _repo = repo;
            _staff = staff;
            this.Loaded += load;
            productListView.SelectionChanged += itemProductListView_click;
            btnAdd.Click += btnAdd_click;
            btnDelete.Click += btnDelete_click;
            btnSave.Click += btnSave_click;
            btnUpdate.Click += btnUpdate_Click;
            orderDetails = new List<OrderDetail>();
            orderDetailsListView.SelectionChanged += OrderDetailsListView_SelectionChanged; ;
            txtId.IsEnabled = false;
            txtName.IsEnabled = false;
            txtPrice.IsEnabled = false;
        }

        private void OrderDetailsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int index = orderDetailsListView.SelectedIndex;
                OrderDetail od = orderDetails[index];
                txtId.Text = od.ProductId.ToString();
                txtName.Text = od.Product.ProductName;
                txtQuantity.Text = od.Quantity.ToString();
                txtPrice.Text = od.UnitPrice.ToString();
            }
            catch (Exception ex) { return; }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = orderDetailsListView.SelectedIndex;
                orderDetails[index].Quantity = int.Parse(txtQuantity.Text);
                ShowOrderDetail();
            }
            catch { return;}
        }

        private void load(object sender, RoutedEventArgs e)
        {
            ShowListProduct();
        }
        private void ShowListProduct()
        {
            var products = _repo.ProductRepository.FindAll();
            productListView.ItemsSource = products;
        }
        private void itemProductListView_click(object sender,RoutedEventArgs e)
        {
            try
            {
                var product = productListView.SelectedItem as Product;
                txtId.Text = product.ProductId.ToString();
                txtName.Text = product.ProductName;
                txtQuantity.Text = "1";
                txtPrice.Text = product.UnitPrice.ToString();
            }
            catch{ return; }
        }
        private void btnAdd_click(object sender,RoutedEventArgs e)
        {
            var product = productListView.SelectedItem as Product;
            var orderdetail = new OrderDetail()
            {
                OrderDetailId = 0,
                ProductId = product.ProductId,
                Quantity = int.Parse(txtQuantity.Text),
                UnitPrice = product.UnitPrice,
                Product = product,
            };
            if (checkOrderDetasils(product.ProductId))
            {
                orderDetails.Add(orderdetail);
                ShowOrderDetail();
            }
            
        }
        private void btnDelete_click(object sender,RoutedEventArgs e)
        {
            try
            {
                int index = orderDetailsListView.SelectedIndex;
                orderDetails.RemoveAt(index);
                ShowOrderDetail();
            }
            catch(Exception ex)
            {
                return;
            }
            
        }
        private void btnSave_click(object sender,RoutedEventArgs e)
        {
            if (orderDetails.Count != 0)
            {
                Order order = new Order()
                {
                    OrderDate = DateTime.Now,
                    StaffId = _staff.StaffId,
                    OrderDetails = orderDetails
                };
                int result = _repo.OrderRepository.Add(order);
                if (result != 0)
                {
                    MessageBox.Show("OrderSuccess!");
                    this.Close();
                }
            }
        }
        bool checkOrderDetasils(int id)
        {
            return orderDetails.Any(od=>od.ProductId == id)?false:true;
        }
        private void ShowOrderDetail()
        {
            orderDetailsListView.ItemsSource = null;
            orderDetailsListView.ItemsSource = orderDetails;
            int total = 0;
            foreach (OrderDetail od in orderDetails)
            {
                total += (od.Quantity * od.UnitPrice);
            }
            txtTotal.Text = total.ToString();
        }
    }
}
