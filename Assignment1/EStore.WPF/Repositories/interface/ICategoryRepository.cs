using EStore.WPF.Models;

namespace EStore.WPF.Repositories
{
    public interface ICategoryRepository
    {
        Category FindById(int id);
        IList<Category> FindAll();
        int Add(Category category);
        int Update(Category category);
        int Delete(int id);

    }
}
