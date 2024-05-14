using EStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Core.repository
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
