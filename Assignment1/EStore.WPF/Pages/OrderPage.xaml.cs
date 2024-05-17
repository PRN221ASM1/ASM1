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
        public OrderPage(RepositoryManager repo,Staff staff)
        {
            InitializeComponent();
            _repo = repo;
            _staff = staff;

            this.Loaded += Load;
            orderListView.SelectionChanged += ItemOrderListView_SelectionChanged;
            foreach(MenuItem item in menuCRUDOrder.Items)
            {
                item.Click += itemMenuCRUDOrder_click;
            }
            cobStaffs.SelectionChanged += CobSelection_chance;
            btnDateFilter.Click += BtnDateFilter_Click;
            
        }

        private void BtnDateFilter_Click(object sender, RoutedEventArgs e)
        {
            ShowListOrder();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            StartDate.SelectedDate = DateTime.Now.AddDays(-4);
            EndtDate.SelectedDate = DateTime.Now;
            SetControll();
            SetFilterOrder();
            ShowListOrder();
        }
        private void ShowListOrder()
        {
            try
            {
                DateTime start = StartDate.SelectedDate.Value;
                DateTime end = EndtDate.SelectedDate.Value;
                var orders = _repo.OrderRepository.GetOrderByDate(start, end);
                if (cobStaffs.SelectedItem == null)
                {
                    cobStaffs.SelectedIndex = 0;
                }
                var staff = cobStaffs.SelectedItem as Staff;

                if (_staff.Role == 1)
                {
                    orders = orders.Where(o => o.StaffId == _staff.StaffId).ToList();
                }
                else if(_staff.Role == 0)
                {
                    if (staff.StaffId != 0)
                    {
                        orders = orders.Where(o => o.StaffId == staff.StaffId).ToList();
                    }
                }
                orderListView.ItemsSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetFilterOrder()
        {
            StartDate.SelectedDate = DateTime.Now;
            EndtDate.SelectedDate = DateTime.Now;
            var staffs = new List<Staff>() { new Staff() { StaffId = 0, Name = "All" } };
            staffs.AddRange(_repo.StaffRepository.FindAll());
            cobStaffs.ItemsSource = staffs;
            cobStaffs.DisplayMemberPath = "Name";
            cobStaffs.SelectedIndex = 0;
        }
        private void ItemOrderListView_SelectionChanged(Object sender,RoutedEventArgs e)
        {
           try
            {
                var order = orderListView.SelectedItem as Order;
                orderDetailsListView.ItemsSource = _repo.OrderRepository.GeOrderDetails(order.OrderId);
                double total = 0;
                foreach (var item in order.OrderDetails)
                {
                    total += (item.Quantity * item.UnitPrice);
                }
                txtTotalPriceDetail.Text = total.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetControll()
        {
            if (_staff.Role == 1)
            {
                foreach(MenuItem item in menuFilterOrders.Items)
                {
                    if (item.Name == "Staff")
                    {
                        item.IsEnabled = true;
                    }
                }
            }
            else if(_staff.Role == 0)
            {
                //
            }
        }
        private void itemMenuCRUDOrder_click(object sender, RoutedEventArgs e)
        {
            var item = (sender as MenuItem);
            switch (item.Name)
            {
                case "Add":
                    Window createOd = new CreateOrder(_repo, _staff);
                    createOd.Closed += CreateOd_Closed;
                    createOd.Show();
                    break;
                case "Update":
                    break;
                case "Delete":
                    break;
            }
        }

        private void CreateOd_Closed(object? sender, EventArgs e)
        {
            StartDate.SelectedDate = DateTime.Now.AddDays(-4);
            EndtDate.SelectedDate = DateTime.Now;
            ShowListOrder();
        }
        private void CobSelection_chance(object sender,RoutedEventArgs e)
        {
            ShowListOrder();
        }
    }
}
