using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Producto> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Producto>();
    }

    public void AddProduct(Producto product)
    {
        _products.Add(product);
    }

    private double GetShippingCost()
    {
        return _customer.LivesInUSA() ? 5.0 : 35.0;
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Producto p in _products)
        {
            total += p.GetTotalCost();
        }
        return total + GetShippingCost();
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Producto p in _products)
        {
            sb.AppendLine($"{p.GetName()} - {p.GetProductId()}");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetShippingLabel();
    }
}
