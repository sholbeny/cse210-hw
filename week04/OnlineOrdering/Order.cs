using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private string _orderNumber;
    private int _deliveryDays;

    public Order(Customer customer, string orderNumber)
    {
        _customer = customer;
        _orderNumber = orderNumber;
        _products = new List<Product>();

        if (_customer.IsInUSA())
        {
            _deliveryDays = 4;
        }
        else
        {
            _deliveryDays = 9;
        }
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.IsInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();

        foreach (Product product in _products)
        {
            label.AppendLine(
                $"{product.GetName()} - {product.GetProductId()}"
            );
        }

        return label.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n"
            + $"{_customer.GetAddress().GetFullAddress()}";
    }

    public string GetOrderNumber()
    {
        return _orderNumber;
    }

    public int GetDeliveryDays()
    {
        return _deliveryDays;
    }
}