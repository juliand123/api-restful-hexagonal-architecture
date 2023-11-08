using AwesomeShop.Core.Entities.Orders;

namespace AwesomeShop.Core.Repositories.Orders;

public interface IOrderRepository
{
    Task<Order> GetById(int id);
    Task<List<Order>> GetAll();
    Task<int> Add(Order order);
}