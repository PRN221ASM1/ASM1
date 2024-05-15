using EStore.Core.Model;
using EStore.Core.repository;
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
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryPage(ICategoryRepository categoryRepository)
        {
            InitializeComponent();
            _categoryRepository = categoryRepository;
            this.Loaded += Load;
            btnAdd.Click += btnAdd_click;
            btnUpdate.Click += btnUpdate_click;
            btnDelete.Click += btnDelete_click;
            textCategoryId.IsEnabled = false;
            categoryListView.SelectionChanged += CategoryListViewItem_click;
        }
        private void CategoryListViewItem_click(object sender, RoutedEventArgs e)
        {
            var cate = categoryListView.SelectedItem as Category;
            if (cate != null)
            {
                textCategoryId.Text = cate.CategoryId.ToString();
                textCategoryName.Text = cate.CategoryName.ToString();
            }
            else { return; }
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            ShowListCategory();
        }
        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textCategoryName.Text))
            {
                AddCategory();
            }
            else
            {
                MessageBox.Show("Category not empty");
                return;
            }
        }
        private void btnUpdate_click(object sender, RoutedEventArgs e)
        {
            UpdateCategory();
        }
        private void btnDelete_click(object sender, RoutedEventArgs e)
        {
            DeleteCategory();
        }
        private void AddCategory()
        {
            try
            {
                string categoryName = textCategoryName.Text;
                Category cate = new Category() { CategoryName = categoryName };
                int result = _categoryRepository.Add(cate);
                if (result > 0)
                {
                    ShowListCategory();
                    MessageBox.Show("Add success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateCategory()
        {
            try
            {
                var cate = categoryListView.SelectedItem as Category;
                if (cate != null)
                {
                    cate.CategoryName = textCategoryName.Text;
                    int result = _categoryRepository.Update(cate);
                    if (result > 0)
                    {
                        ShowListCategory();
                        MessageBox.Show("Update success");
                    }
                }
                else
                {
                    MessageBox.Show("Can not update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteCategory()
        {
            try
            {
                Category cate = categoryListView.SelectedItem as Category;
                if (cate != null)
                {
                    int result = _categoryRepository.Delete(cate.CategoryId);
                    if (result > 0)
                    {
                        ShowListCategory();
                        MessageBox.Show("Delete success");
                    }
                }
                else
                {
                    MessageBox.Show("Can not delete");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowListCategory()
        {
            var categories = _categoryRepository.FindAll();
            if (categories != null)
            {
                categoryListView.ItemsSource = categories;
            }
        }

    }
}
