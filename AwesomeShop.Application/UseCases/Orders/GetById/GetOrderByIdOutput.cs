using AwesomeShop.Core.Entities;
using AwesomeShop.Core.Entities.Orders;

namespace AwesomeShop.Application.UseCases.Orders.GetById;

public class GetOrderByIdOutput
{
    public GetOrderByIdOutput(Order order)
    {
        Id = order.Id;
        OrderCode = order.OrderCode;
        CustomerName = order.CustomerName;
        CustomerEmail = order.CustomerEmail;
        TotalCost = order.TotalCost;
        //Items = order.Items.Select(i => $"Product {i.ProductName}, Quantity {i.Quantity}").ToList();
        Status = (int)order.Status;
        CreatedAt = order.CreatedAt;
    }

    public int Id { get; private set; }
    public string OrderCode { get; private set; }

    public string CustomerName { get; private set; }
    public string CustomerEmail { get; private set; }
    public decimal TotalCost { get; private set; }
    public List<string> Items { get; private set; }
    public int Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
}