using System;
using EStore.Core.Model;
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
using EStore.Core.repository;
using EStore.WPF.Pages;

namespace EStore.WPF.Windows.Members
{
    /// <summary>
    /// Interaction logic for UpdateMemberPage.xaml
    /// </summary>
    public partial class UpdateMemberPage : Page
    {
        private readonly IMemberRepository _memberRepository;
        private readonly Member _memberToUpdate;

        public UpdateMemberPage(IMemberRepository memberRepository, Member memberToUpdate)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            _memberToUpdate = memberToUpdate;
            txtEmail.Text = _memberToUpdate.Email;
            txtCompanyName.Text = _memberToUpdate.CompanyName;
            txtCity.Text = _memberToUpdate.City;
            txtCountry.Text = _memberToUpdate.Country;
            txtPassword.Text = _memberToUpdate.Password;
        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                   string.IsNullOrWhiteSpace(txtCompanyName.Text) ||
                   string.IsNullOrWhiteSpace(txtCity.Text) ||
                   string.IsNullOrWhiteSpace(txtCountry.Text) ||
                   string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please input all fields.");
                return;
            }

            try
            {
                _memberToUpdate.Email = txtEmail.Text;
                _memberToUpdate.CompanyName = txtCompanyName.Text;
                _memberToUpdate.City = txtCity.Text;
                _memberToUpdate.Country = txtCountry.Text;
                _memberToUpdate.Password = txtPassword.Text;
                int result = _memberRepository.Update(_memberToUpdate);
                if (result > 0)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Added", "Success", MessageBoxButton.OK);
                    if (messageBoxResult == MessageBoxResult.OK)
                    {
                        MemberPage memberPage = new MemberPage(_memberRepository);
                        this.NavigationService.Navigate(memberPage);
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
