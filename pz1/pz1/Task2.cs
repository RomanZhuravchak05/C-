using System;
using System.Linq;

public class Task2
{
    public static void Run()
    {
        Console.WriteLine("Завдання 2");

        Console.Write("Введіть три сторони трикутника (через пробіл): ");
        var sides = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

        if (sides.Length != 3)
        {
            Console.WriteLine("Невірна кількість сторін!");
            return;
        }

        if (sides[0] + sides[1] <= sides[2] || sides[1] + sides[2] <= sides[0] || sides[2] + sides[0] <= sides[1])
        {
            Console.WriteLine("Трикутник з такими сторонами побудувати неможливо.");
            return;
        }

        double perimeter = sides.Sum();

        double semiPerimeter = perimeter / 2;
        double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sides[0]) * (semiPerimeter - sides[1]) * (semiPerimeter - sides[2]));

        string triangleType = "Невідомий";
        if (sides[0] == sides[1] && sides[1] == sides[2])
            triangleType = "Рівносторонній";
        else if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[2])
            triangleType = "Рівнобедрений";
        else
            triangleType = "Різносторонній";

        Console.WriteLine($"Периметр трикутника: {perimeter}");
        Console.WriteLine($"Площа трикутника: {area}");
        Console.WriteLine($"Тип трикутника: {triangleType}");
        Console.WriteLine();
    }
}

