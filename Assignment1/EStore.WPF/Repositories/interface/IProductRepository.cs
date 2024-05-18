using EStore.WPF.Models;

namespace EStore.WPF.Repositories
{
    public interface IProductRepository
    {
        Product FindById(int id);
        IList<Product> FindAll();
        int Add(Product product);
        int Update(Product product);
        int Delete(int id);
        List<Product> GetByCategory(int categoryId);
        IList<Product> SearchByName(string searchText);
    }
}
