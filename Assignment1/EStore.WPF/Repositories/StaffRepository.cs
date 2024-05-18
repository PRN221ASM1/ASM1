
using EStore.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.WPF.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly MyStoreContext _context;
        public StaffRepository(MyStoreContext context)
        {
            _context = context;
        }
        public int Add(Staff staff)
        {
            _context.Staffs.Add(staff);
            int result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            Staff staff = _context.Staffs.FirstOrDefault(m=>m.StaffId == id);
            if (staff != null)
            {
               _context.Staffs.Remove(staff);
                int result = _context.SaveChanges();
                return result;
            }
            return 0;
        }
        public Staff FindById(int id)
        {
            Staff staff = _context.Staffs.FirstOrDefault(m => m.StaffId == id);
            return staff;
        }
        public IList<Staff> FindByName(string name)
        {
            return _context.Staffs.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public IList<Staff> FindAll()
        {
            List<Staff> members = _context.Staffs.ToList();
            return members;
        }

        public Staff Login(string name, string password)
        {
            return _context.Staffs.FirstOrDefault(s => s.Name.ToLower() == name.ToLower() && s.Password == password);
        }


        public int Update(Staff staff)
        {
            _context.Staffs.Update(staff);
            int result = (_context.SaveChanges());
            return result;
        }
        public bool IsNameExists(string name)
        {
            return _context.Staffs.Any(staff => staff.Name.ToUpper() == name.Trim().ToUpper());
        }
    }
}
