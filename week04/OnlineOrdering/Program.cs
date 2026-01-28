/*
 * Creativity:
 * I formatted the output with clear headings and separators so each order’s
 * packing label, shipping label, and total price are easy to read—similar to a
 * real order summary—without adding any user interaction or extra features.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        // ORDER 1 (USA)
        Address address1 = new Address("123 Main St", "Orem", "UT", "USA");
        Customer customer1 = new Customer("Armando Rebaza", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "P1001", 2.50, 4));
        order1.AddProduct(new Product("Pen Pack", "P2002", 3.00, 2));
        order1.AddProduct(new Product("USB Drive", "P3003", 9.99, 1));

        // ORDER 2 (International)
        Address address2 = new Address("Av. Arequipa 555", "Lima", "Lima", "Peru");
        Customer customer2 = new Customer("Jessica Rebaza", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone Case", "P4004", 12.00, 1));
        order2.AddProduct(new Product("Charger", "P5005", 15.50, 1));

        DisplayOrder("ORDER 1", order1);
        DisplayOrder("ORDER 2", order2);
    }

    static void DisplayOrder(string title, Order order)
    {
        Console.WriteLine("========================================");
        Console.WriteLine(title);
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
        Console.WriteLine("========================================\n");
    }
}
