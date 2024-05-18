
using EStore.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.WPF.Repositories
{
    public interface IStaffRepository
    {
        Staff FindById(int id);
        Staff Login(string name, string password);
        IList<Staff> FindAll();
        int Add(Staff staff);
        int Update(Staff staff);
        int Delete(int id);
        IList<Staff> FindByName(string name);
        bool IsNameExists(string name);
    }
}
