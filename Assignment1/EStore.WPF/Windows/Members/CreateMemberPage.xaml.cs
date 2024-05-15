using EStore.Core.repository;
using EStore.Core.Model;
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
using EStore.WPF.Pages;

namespace EStore.WPF.Windows.Members
{
    /// <summary>
    /// Interaction logic for CreateMemberPage.xaml
    /// </summary>
    public partial class CreateMemberPage : Page
    {
        private readonly IMemberRepository _memberRepository;

        public CreateMemberPage(IMemberRepository memberRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            try
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
                Member member = new Member
                {
                    //MemberId = int.Parse(txtMemberId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };

                int result = _memberRepository.Add(member);
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
