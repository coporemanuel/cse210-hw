using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{name}\n{address.GetFullAddress()}";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal GetTotalPrice()
    {
    decimal totalCost = 0;
    foreach (Product product in products)
    {
        totalCost += product.GetTotalCost();
    }

    if (customer.LivesInUSA())
    {
        totalCost += 5;
    }
    else
    {
        totalCost += 35;
    }

    return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetShippingLabel()}";
    }
}

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A123", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "B456", 10.50m, 5));

        Address address2 = new Address("649 South St", "Bermejo", "TJ", "Bolivia");
        Customer customer2 = new Customer("Manuel Copore", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Tablet", "C789", 600.70m, 2));
        order2.AddProduct(new Product("Keyboard", "D012", 30.40m, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}
