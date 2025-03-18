using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("uk-UA");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("uk-UA");

        var apple = new Product("Яблуко", 5, 100);
        Console.WriteLine(apple.GetInfo());

        apple.Sell(20);
        Console.WriteLine(apple.GetInfo());

        apple.Restock(50);
        Console.WriteLine(apple.GetInfo());

        apple.Price = 7;
        Console.WriteLine(apple.GetInfo());

        apple.Name = "Зелене яблуко";
        Console.WriteLine(apple.GetInfo());

        try
        {
            apple.Price = -10;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            apple.Name = "";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        apple.Sell(200);
    }
}
