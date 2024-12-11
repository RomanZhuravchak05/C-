using System;
using System.Linq;

public class Task4
{
    public static void Run()
    {

        int studentLastDigit = 5;
        int arrayLength = 10 + studentLastDigit;

        Console.WriteLine("Завдання 4");

        Random rand = new Random();
        var arrayX = Enumerable.Range(0, arrayLength).Select(_ => rand.Next(-100, 101)).ToArray();

        Console.Write("Введіть число M: ");
        int M = int.Parse(Console.ReadLine());

        
        var arrayY = arrayX.Where(x => Math.Abs(x) > Math.Abs(M)).ToArray();

        Console.WriteLine($"Масив X: {string.Join(", ", arrayX)}");
        Console.WriteLine($"Число M: {M}");
        Console.WriteLine($"Масив Y: {string.Join(", ", arrayY)}");
        Console.WriteLine();
    }
}
