using AwesomeShop.Core.Entities.Orders;
using AwesomeShop.Core.Enums.Orders;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

public class Order : TableEntity
{
    public Order(string orderCode, string customerName, string customerEmail, List<OrderItem> items)
    {
        PartitionKey = GeneratePartitionKey();
          RowKey = GenerateRowKey();
          OrderCode = orderCode;
          CustomerName = customerName;
        CustomerEmail = customerEmail;
        Items = JsonConvert.SerializeObject(items);

        TotalCost = items.Sum(i => i.Quantity * i.UnitPrice);
        Status = OrderStatusEnum.StartedAndPaymentPending;
        CreatedAt = DateTime.Now;

        ShipmentDate = DateTime.Now;
    }

    public int Id { get; private set; }
    public string OrderCode { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string Items { get; set; }

    public decimal TotalCost { get; set; }
    public OrderStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime ShipmentDate { get; set; }

    private string GeneratePartitionKey()
    {
        string year = DateTime.Now.Year.ToString();
        return year;
    }
    private string GenerateRowKey()
    {
        return Guid.NewGuid().ToString();
    }
}

