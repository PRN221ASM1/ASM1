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
    public class OrderRepository : IOrderRepository
    {
        private readonly EStoreContext _context;
        public OrderRepository(EStoreContext context)
        {
            _context = context;
        }

        public int Add(Order order)
        {
            _context.Orders.Add(order);
            int result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            _context.Orders.Remove(FindById(id));
            int result =  _context.SaveChanges();
            return result;
        }

        public Order FindById(int id)
        {
            Order order = _context.Orders.Include(o=>o.Member)
                .FirstOrDefault(o=>o.OrderId == id);
            return order;
        }

        public IList<Order> FindAll()
        {
            List<Order> orders = _context.Orders.Include(o => o.Member).ToList();
            return orders;
        }

        public int Update(Order order)
        {
            _context.Orders.Update(order);
            int result = _context.SaveChanges();
            return result;
        }
    }
}
