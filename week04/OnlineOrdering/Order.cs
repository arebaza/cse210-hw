using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
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

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += GetShippingCost();
        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product product in _products)
        {
            sb.AppendLine($"{product.GetName()} - {product.GetProductId()}");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetShippingLabel();
    }
}
