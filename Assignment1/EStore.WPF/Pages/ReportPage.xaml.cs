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
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        private readonly RepositoryManager _repo;
        private readonly Staff _staff;

        public ReportPage(RepositoryManager repo,Staff staff)
        {
            InitializeComponent();
            _repo = repo;
            _staff = staff;
        }
    }
}
