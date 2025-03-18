using System;
using System.Globalization;
using System.Text;

class Product
{
    private string _name;
    private decimal _price;
    private int _quantity;

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        _quantity = quantity;
    }

    public string Name
    {
        get => _name;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                _name = value;
            else
                throw new ArgumentException("Назва товару не може бути порожньою.");
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value >= 0)
                _price = value;
            else
                throw new ArgumentException("Ціна не може бути від'ємною.");
        }
    }

    public int Quantity => _quantity;
    public decimal TotalValue => _price * _quantity;

    public void Restock(int amount)
    {
        if (amount > 0)
            _quantity += amount;
        else
            throw new ArgumentException("Кількість для поповнення має бути додатною.");
    }

    public void Sell(int amount)
    {
        if (amount > 0 && amount <= _quantity)
            _quantity -= amount;
        else
            Console.WriteLine("Недостатньо товару на складі!");
    }

    public string GetInfo()
    {
        var culture = new CultureInfo("uk-UA");
        return $"Товар: {_name}, Ціна: {_price.ToString("C", culture)}, Кількість: {_quantity}, Загальна вартість: {TotalValue.ToString("C", culture)}";
    }
}