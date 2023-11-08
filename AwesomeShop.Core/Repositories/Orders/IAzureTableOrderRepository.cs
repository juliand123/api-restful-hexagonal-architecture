using AwesomeShop.Core.Entities.Orders;

namespace AwesomeShop.Core.Repositories.Orders
{
    public interface IAzureTableOrderRepository
    {
        Task<int> Add(Order order);
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
    }
}
