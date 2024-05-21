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
    /// Interaction logic for AdminProfilePage.xaml
    /// </summary>
    public partial class AdminProfilePage : Page
    {
        private readonly Staff _staff;
        private readonly RepositoryManager _repositoryManager;

        public AdminProfilePage(Staff staff, RepositoryManager repositoryManager)
        {
            InitializeComponent();
            this.Loaded += Load;
            _staff = staff;
            _repositoryManager = repositoryManager;

            if (staff != null)
            {
                System.Diagnostics.Debug.WriteLine($"Staff details - ID: {staff.StaffId}, Name: {staff.Name}, Password: {staff.Password}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Staff object is null");
            }


            _staff = staff;
            _repositoryManager = repositoryManager;
        }

        private void lstMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (staffListView.SelectedItem != null)
            {
                Staff staff = staffListView.SelectedItem as Staff;
                txtName.Text = staff.Name;
                txtPassword.Text = staff.Password;
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            if (_staff.Role == 0)
            {
                List<Staff> loggedInStaffList = new List<Staff> { _staff };
                staffListView.ItemsSource = loggedInStaffList;
            }
            else
            {
                var staff = _repositoryManager.StaffRepository.FindAll();
                if (staff != null)
                {
                    staffListView.ItemsSource = staff;
                }
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lstMember_SelectionChanged == null)
            {
                MessageBox.Show("Please select item");
            }
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please input all fields.");
                return;
            }
            try
            {
                Staff staff = (Staff)staffListView.SelectedItem;
                staff.Name = txtName.Text;
                staff.Password = txtPassword.Text;
                int result = _repositoryManager.StaffRepository.Update(staff);
                if (result > 0)
                {
                    MessageBox.Show("Updated");

                    if (_staff.Role == 0)
                    {
                        List<Staff> loggedInStaffList = new List<Staff> { _staff };
                        staffListView.ItemsSource = loggedInStaffList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
