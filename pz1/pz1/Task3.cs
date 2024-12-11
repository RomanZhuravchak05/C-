using System;
using System.Linq;

public class Task3
{
    public static void Run()
    {

        int studentLastDigit = 5;
        int arrayLength = 10 + studentLastDigit;

        Console.WriteLine("Завдання 3");

        Random rand = new Random();
        var array = Enumerable.Range(0, arrayLength).Select(_ => rand.Next(-100, 101)).ToArray();

        int min = array.Min();
        int max = array.Max();

        Console.WriteLine($"Масив: {string.Join(", ", array)}");
        Console.WriteLine($"Мінімальне значення: {min}");
        Console.WriteLine($"Максимальне значення: {max}");
        Console.WriteLine();
    }
}
