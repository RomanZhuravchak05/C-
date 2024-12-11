using System;
using System.Linq;

public class Task1
{
    public static void Run()
    {

        int studentLastDigit = 5;

        Console.WriteLine("Завдання 1");

        Console.Write("Введіть три числа (через пробіл): ");
        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int upperBound = 10 + studentLastDigit;
        int lowerBound = 1;

        var result = input.Where(x => x >= lowerBound && x <= upperBound).ToArray();

        Console.WriteLine($"Числа в інтервалі [{lowerBound}, {upperBound}]: {string.Join(", ", result)}");
        Console.WriteLine();
    }
}
