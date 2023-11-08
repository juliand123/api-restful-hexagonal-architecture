namespace AwesomeShop.Core.Enums.Orders;

public enum OrderStatusEnum
{
    StartedAndPaymentPending = 1,
    PreparingForDelivery = 2,
    Shipped = 3,
    Delivered = 4,
    Cancelled = 5
}