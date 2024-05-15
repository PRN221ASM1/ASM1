using EStore.WPF.Models;
using EStore.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        private readonly RepositoryManager _repo;
        private readonly Staff _staff;
        public StaffPage(RepositoryManager repo,Staff staff)
        {
            InitializeComponent();
            _repo = repo;
            _staff = staff;
            SetControl();
            this.Loaded += Load;
        }
        private void SetControl()
        {
            if (_staff.Role == 1)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
            }
            else if (_staff.Role == 0)
            {
                btnAdd.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Staff staff = new Staff
                {
                    //StaffId = int.Parse(txtStaffId.Text),
                    Name = txtName.Text,
                    Password = txtPassword.Text,
                };
                int result = _repo.StaffRepository.Add(staff);
                if (result > 0)
                {
                    MessageBox.Show("Added");
                    staffListView.ItemsSource = _repo.StaffRepository.FindAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lstMember_SelectionChanged == null)
            {
                MessageBox.Show("Please select item");
            }
            if(string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please input all fields.");
                return;
            }
            try
            {
                Staff staff = (Staff)staffListView.SelectedItem;
                //staff.StaffId = int.Parse(txtStaffId.Text);
                staff.Name = txtName.Text;
                staff.Password = txtPassword.Text;
                int result = _repo.StaffRepository.Update(staff);
                if (result > 0)
                {
                    MessageBox.Show("Updated");
                    staffListView.ItemsSource = _repo.StaffRepository.FindAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (staffListView.SelectedItem == null)
            {
                MessageBox.Show("Please select an item.");
                return;
            }
            try
            {
                Staff staff = (Staff)staffListView.SelectedItem;
                int result = _repo.StaffRepository.Delete(staff.StaffId);
                if (result > 0)
                {
                    MessageBox.Show("Deleted");
                    staffListView.ItemsSource = _repo.StaffRepository.FindAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lstMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (staffListView.SelectedItem != null)
            {
                Staff staff = staffListView.SelectedItem as Staff;
                txtStaffId.Text = staff.StaffId.ToString();
                txtName.Text = staff.Name;
                txtPassword.Text = staff.Password;
            }
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            var staff = _repo.StaffRepository.FindAll();
            if (staff != null)
            {
                staffListView.ItemsSource = staff;
            }
        }
    }
}
