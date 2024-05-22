using EStore.WPF.Models;
using EStore.WPF.Repositories;
using EStore.WPF.Windows.Orders;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EStore.WPF.Pages
{
    /// <summary>
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private readonly RepositoryManager _repo;
        private readonly Staff _staff;
        private readonly List<OrderDetail> _orderDetails;
        public OrderPage(RepositoryManager repo, Staff staff)
        {
            InitializeComponent();
            _repo = repo;
            _staff = staff;
            _orderDetails = new List<OrderDetail>();
        }
        public void Load(object sender, RoutedEventArgs e)
        {
            LoadDataGridOrders();
        }
        private void OrdersActionsClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Order order = dataGridOrders.SelectedItem as Order;
            switch (button.Tag)
            {
                case "Delete":
                    bool result = DeleteOrder(order);
                    if (result)
                    {
                        MessageBox.Show("Delete success");
                        LoadDataGridOrders();
                    }
                break;
                case "Detail":
                    ShowDetailOrder(order);
                    break;
            }
        }
        private void LoadDataGridOrders()
        {
            DateTime start = pickerStartDate.SelectedDate ?? DateTime.Now;
            DateTime end = pickerEndDate.SelectedDate ?? DateTime.Now;
            var orders = _repo.OrderRepository.GetOrderByDate(start, end);
            dataGridOrders.ItemsSource = null;
            dataGridOrders.ItemsSource = orders;
        }
        private void ShowDetailOrder(Order? order)
        {
            var orderDetails = _repo.OrderRepository.GeOrderDetails(order.OrderId);
            dataGridOrderDetails.ItemsSource = null;
            dataGridOrderDetails.ItemsSource = orderDetails;
            int total = 0;
            foreach ( var item in orderDetails)
            {
                total += (item.Quantity * item.UnitPrice);
            }
            lableTotal.Content = $"Total: {total}$";
        }
        private void LoadDetailOrder()
        {
            
            dataGridOrderDetails.ItemsSource = null;
            dataGridOrderDetails.ItemsSource = _orderDetails;
            int total = 0;
            foreach (var item in _orderDetails)
            {
                total += (item.Quantity * item.UnitPrice);
            }
            
            lableTotal.Content = $"Total: {total}$";
        }
        private bool DeleteOrder(Order? order)
        {
            int result = _repo.OrderRepository.Delete(order.OrderId);
            return result > 0 ;
        }
        private void DateChanged(object sender,RoutedEventArgs e)
        {
            LoadDataGridOrders();
        }
        private void CheckProduct(object sender,RoutedEventArgs e)
        {
            try
            {
                int pId = int.Parse(txtProductId.Text);
                Product p = _repo.ProductRepository.FindById(pId);
                if (p != null)
                {
                    txtProductName.Text = p.ProductName;
                    txtQuantity.Text = "1";
                    txtUnitPrice.Text = p.UnitPrice.ToString();
                }
                else
                {
                    MessageBox.Show("Can not found");
                }
            }catch(Exception ex)
            {
                return;
            }
        }
        private void AddProductDetail(object sender,RoutedEventArgs e)
        {
            try
            {
                int pId = int.Parse(txtProductId.Text);
                OrderDetail dl = new OrderDetail()
                {
                    OrderDetailId =0,
                    OrderId = 0,
                    ProductId = pId,
                    Quantity = int.Parse(txtQuantity.Text),
                    UnitPrice = int.Parse(txtUnitPrice.Text)
                };
                _orderDetails.Add(dl);
                LoadDetailOrder();
            }
            catch(Exception ex)
            {
                return;
            }
        }
        private void CreateOrder(object sender,RoutedEventArgs e)
        {
            try
            {  Order order = new Order()
            {
                StaffId = _staff.StaffId,
                OrderDate = DateTime.Now,
                OrderDetails = _orderDetails.ToList()
            };
                int result = _repo.OrderRepository.Add(order);
                if (result != 0)
                {
                    _orderDetails.Clear();
                    MessageBox.Show("Create success");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void OrdersDetailActionsClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // Ensure that the DataGrid has a selected item
                if (dataGridOrderDetails.SelectedItem is OrderDetail odl && dataGridOrderDetails.SelectedIndex >= 0)
                {
                    int index = dataGridOrderDetails.SelectedIndex;

                    switch (button.Tag.ToString())
                    {
                        case "Delete":
                            // Remove the selected OrderDetail from the list
                            _orderDetails.RemoveAt(index);
                            LoadDetailOrder();
                            break;
                        default:
                            MessageBox.Show("Unknown action");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("No item selected or invalid selection.");
                }
            }
            else
            {
                MessageBox.Show("Invalid sender.");
            }
        }
        private void OrdersDetailActionsClick(object sender, DataGridCellEditEndingEventArgs e)
        {
            OrderDetail odl = dataGridOrderDetails.SelectedItem as OrderDetail;
            int index = dataGridOrderDetails.SelectedIndex;
            if (e.Column.DisplayIndex == 2)
            {
                TextBox textBox = e.EditingElement as TextBox;
                if (textBox != null)
                {
                   odl.Quantity = int.Parse(textBox.Text);
                    _orderDetails[index] = odl;
                }
            }
            LoadDetailOrder();
        }

    }
}
