using EStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Core.repository
{
    public interface IProductRepository
    {
        Product FindById(int id);
        IList<Product> FindAll();
        int Add(Product product);
        int Update(Product product);
        int Delete(int id);
    }
}
