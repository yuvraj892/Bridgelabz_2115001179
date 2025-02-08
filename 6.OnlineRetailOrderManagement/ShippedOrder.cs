
// Subclass representing a Shipped Order
class ShippedOrder : Order
{
    // Additional attribute for tracking number
    public string TrackingNumber { get; private set; }

    // Constructor to initialize a shipped order
    public ShippedOrder(int orderId, string orderDate, string trackingNumber) : base(orderId, orderDate)
    {
        TrackingNumber = trackingNumber;
    }

    // Overriding method to get order status
    public override void GetOrderStatus()
    {
        Console.WriteLine($"Order ID: {OrderId}, Order Date: {OrderDate}, Tracking Number: {TrackingNumber}, Status: Shipped");
    }
}
