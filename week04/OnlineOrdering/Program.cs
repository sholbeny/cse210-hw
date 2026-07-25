using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the first customer's address.
        Address address1 = new Address(
            "123 Main Street",
            "Minneapolis",
            "Minnesota",
            "USA"
        );

        // Create the first customer.
        Customer customer1 = new Customer(
            "Samantha Holbeny",
            address1
        );

        // Create the first order.
        Order order1 = new Order(customer1);

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

        // Create the second customer's address.
        Address address2 = new Address(
            "15 Hauptstrasse",
            "Heidelberg",
            "Baden-Württemberg",
            "Germany"
        );

        // Create the second customer.
        Customer customer2 = new Customer(
            "Anna Müller",
            address2
        );

        // Create the second order.
        Order order2 = new Order(customer2);

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

        // Display the first order.
        DisplayOrder(order1, 1);

        // Display the second order.
        DisplayOrder(order2, 2);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"ORDER #{orderNumber}");
        Console.WriteLine("========================================");
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