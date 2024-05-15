﻿
using EStore.WPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.WPF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyStoreContext _context;
        public OrderRepository(MyStoreContext context)
        {
            _context = context;
        }

        public int Add(Order order)
        {
            _context.Orders.Add(order);
            _context.OrderDetails.AddRange(order.OrderDetails);
            if (order.OrderDetails.Count() != 0)
            {
                int result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public int Delete(int id)
        {
            _context.Orders.Remove(FindById(id));
            int result =  _context.SaveChanges();
            return result;
        }

        public Order FindById(int id)
        {
            Order order = _context.Orders.Include(o=>o.Staff)
                .FirstOrDefault(o=>o.OrderId == id);
            return order;
        }

        public IList<Order> FindAll()
        {
            List<Order> orders = _context.Orders.Include(o => o.Staff).ToList();
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