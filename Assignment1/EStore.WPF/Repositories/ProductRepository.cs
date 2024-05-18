﻿
using EStore.WPF.Models;
using Microsoft.EntityFrameworkCore;

namespace EStore.WPF.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreContext _context;
        public ProductRepository(MyStoreContext context)
        {
            _context = context;
        }
        public int Add(Product product)
        {
            _context.Products.Add(product);
            int result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            _context.Products.Remove(FindById(id));
            int result = _context.SaveChanges();
            return result;
        }

        public Product FindById(int id)
        {
            Product product = _context.Products.Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);
            return product;
        }

        public IList<Product> FindAll()
        {
            List<Product> products = _context.Products.Include(p => p.Category).ToList();
            return products;
        }

        public int Update(Product product)
        {
            _context.Products.Update(product);
            int result = (_context.SaveChanges());
            return result;
        }
        public List<Product> GetByCategory(int categoryId)
        {
            if (categoryId != 0)
            {
                return _context.Products.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToList();
            }
            else
            {
                return _context.Products.Include(p => p.Category).ToList();
            }
        }
        public IList<Product> SearchByName(string searchText)
        {
            // Chuyển đổi tên sản phẩm được nhập thành chữ thường để tìm kiếm không phân biệt hoa thường
            searchText = searchText.ToLower();

            // Lọc danh sách sản phẩm dựa trên tên sản phẩm
            var filteredProducts = _context.Products
                                    .Include(p => p.Category)
                                    .Where(p => p.ProductName.ToLower().Contains(searchText))
                                    .ToList();

            return filteredProducts;
        }
    }
}
