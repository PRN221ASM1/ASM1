using EStore.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.WPF.Repositories
{
    public interface IOrderRepository
    {
        Order FindById(int id);
        IList<Order> FindAll();
        int Add(Order order);
        int Update(Order order);
        int Delete(int id);
        List<Order> GetOrderByDate(DateTime date);
        List<OrderDetail> GeOrderDetails(int orderId);
    }
}
