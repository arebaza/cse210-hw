/*
 * Creativity:
 * I used clear labels and formatting to make the output easy to read,
 * similar to a real order summary. This improves clarity without adding
 * extra functionality or user interaction.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        Address a1 = new Address("123 Main St", "Orem", "UT", "USA");
        Customer c1 = new Customer("Armando Rebaza", a1);

        Order o1 = new Order(c1);
        o1.AddProduct(new Producto("Notebook", "P1001", 2.50, 4));
        o1.AddProduct(new Producto("Pen Pack", "P2002", 3.00, 2));
        o1.AddProduct(new Producto("USB Drive", "P3003", 9.99, 1));

        Address a2 = new Address("Av. Arequipa 555", "Lima", "Lima", "Peru");
        Customer c2 = new Customer("Jessica Rebaza", a2);

        Order o2 = new Order(c2);
        o2.AddProduct(new Producto("Phone Case", "P4004", 12.00, 1));
        o2.AddProduct(new Producto("Charger", "P5005", 15.50, 1));

        DisplayOrder("ORDER 1", o1);
        DisplayOrder("ORDER 2", o2);
    }

    static void DisplayOrder(string title, Order order)
    {
        Console.WriteLine("========================================");
        Console.WriteLine(title);
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
    }
}
