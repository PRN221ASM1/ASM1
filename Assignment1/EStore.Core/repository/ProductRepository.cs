using EStore.Core.connection;
using EStore.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Core.repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EStoreContext _context;
        public ProductRepository(EStoreContext context)
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
    }
}
