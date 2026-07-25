using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Minneapolis",
            "Minnesota",
            "USA"
        );

        Customer customer1 = new Customer(
            "Samantha Holbeny",
            address1
        );

        Order order1 = new Order(
            customer1,
            "1001"
        );

        order1.AddProduct(new Product(
            "Wireless Mouse",
            "WM-101",
            24.99,
            1
        ));

        order1.AddProduct(new Product(
            "Laptop Stand",
            "LS-205",
            39.50,
            1
        ));

        order1.AddProduct(new Product(
            "USB Cable",
            "USB-310",
            8.75,
            2
        ));

        Address address2 = new Address(
            "15 Hauptstrasse",
            "Heidelberg",
            "Baden-Württemberg",
            "Germany"
        );

        Customer customer2 = new Customer(
            "Anna Müller",
            address2
        );

        Order order2 = new Order(
            customer2,
            "1002"
        );

        order2.AddProduct(new Product(
            "Travel Backpack",
            "TB-400",
            59.99,
            1
        ));

        order2.AddProduct(new Product(
            "Water Bottle",
            "WB-122",
            14.50,
            2
        ));

        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"ORDER #{order.GetOrderNumber()}");
        Console.WriteLine("========================================");
        Console.WriteLine();

        Console.WriteLine(
            $"Estimated Delivery: {order.GetDeliveryDays()} business days"
        );

        Console.WriteLine();

        Console.WriteLine("PACKING LABEL");
        Console.WriteLine("----------------------------------------");
        Console.Write(order.GetPackingLabel());

        Console.WriteLine();

        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine();

        Console.WriteLine(
            $"TOTAL PRICE: ${order.CalculateTotalCost():F2}"
        );

        Console.WriteLine();
    }
}