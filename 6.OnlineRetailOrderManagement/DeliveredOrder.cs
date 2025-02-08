
// Subclass representing a Delivered Order
class DeliveredOrder : ShippedOrder
{
    // Additional attribute for delivery date
    public string DeliveryDate { get; private set; }

    // Constructor to initialize a delivered order
    public DeliveredOrder(int orderId, string orderDate, string trackingNumber, string deliveryDate) : base(orderId, orderDate, trackingNumber)
    {
        DeliveryDate = deliveryDate;
    }

    // Overriding method to get order status
    public override void GetOrderStatus()
    {
        Console.WriteLine($"Order ID: {OrderId}, Order Date: {OrderDate}, Tracking Number: {TrackingNumber}, Delivery Date: {DeliveryDate}, Status: Delivered");
    }
}
