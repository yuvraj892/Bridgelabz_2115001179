// Main Program
using System;

class Program
{
    public static void Main()
    {
        // Creating an order
        Order order = new Order(1001, "2025-02-08");
        order.GetOrderStatus();

        // Creating a shipped order
        ShippedOrder shippedOrder = new ShippedOrder(1002, "2025-02-07", "TRK12345");
        shippedOrder.GetOrderStatus();

        // Creating a delivered order
        DeliveredOrder deliveredOrder = new DeliveredOrder(1003, "2025-02-06", "TRK67890", "2025-02-08");
        deliveredOrder.GetOrderStatus();
    }
}

