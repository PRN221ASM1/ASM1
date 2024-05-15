using EStore.Core.Model;
using EStore.Core.repository;
using EStore.WPF.Windows.Members;
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
    /// Interaction logic for MemberPage.xaml
    /// </summary>
    public partial class MemberPage : Page
    {
        private readonly IMemberRepository _memberRepository;
        public MemberPage(IMemberRepository memberRepository)
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            this.Loaded += Load;
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            CreateMemberPage createMemberPage = new CreateMemberPage(_memberRepository);
            this.NavigationService.Navigate(createMemberPage);
        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            if (lstMember.SelectedItem != null)
            {
                Member member = (Member)lstMember.SelectedItem;
                UpdateMemberPage updateMemberPage = new UpdateMemberPage(_memberRepository, member);
                this.NavigationService.Navigate(updateMemberPage);
            }
            else
            {
                MessageBox.Show("Please select a member to update.");
            }
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (lstMember.SelectedItem == null)
            {
                MessageBox.Show("Please select an item.");
                return;
            }
            try
            {
                Member selectedMember = (Member)lstMember.SelectedItem;
                int result = _memberRepository.Delete(selectedMember.MemberId);
                if (result > 0)
                {
                    MessageBox.Show("Deleted");
                    lstMember.ItemsSource = _memberRepository.FindAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lstMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (lstMember.SelectedItem != null)
            //{
            //    Member member = lstMember.SelectedItem as Member;
            //    txtMemberId.Text = member.MemberId.ToString();
            //    txtEmail.Text = member.Email;
            //    txtCompanyName.Text = member.CompanyName.ToString();
            //    txtCity.Text = member.City.ToString();
            //    txtCountry.Text = member.Country.ToString();
            //    txtPassword.Text = member.Password.ToString();
            //}
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            var member = _memberRepository.FindAll();
            if (member != null)
            {
                lstMember.ItemsSource = member;
            }
        }
    }
}
