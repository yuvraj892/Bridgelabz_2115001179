// Base class representing an Order
class Order
{
    // Properties for order details
    public int OrderId { get; private set; }
    public string OrderDate { get; private set; }

    // Constructor to initialize an order
    public Order(int orderId, string orderDate)
    {
        OrderId = orderId;
        OrderDate = orderDate;
    }

    // Virtual method to get order status
    public virtual void GetOrderStatus()
    {
        Console.WriteLine($"Order ID: {OrderId}, Order Date: {OrderDate}, Status: Processing");
    }
}
