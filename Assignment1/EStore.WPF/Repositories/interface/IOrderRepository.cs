using EStore.WPF.Models;
namespace EStore.WPF.Repositories
{
    public interface IOrderRepository
    {
        Order FindById(int id);
        IList<Order> FindAll();
        int Add(Order order);
        int Update(Order order);
        int Delete(int id);
        List<Order> GetOrderByDate(DateTime from, DateTime to);
        List<OrderDetail> GeOrderDetails(int orderId);
    }
}
