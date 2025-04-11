using System;

class Program
{
    static void Main(string[] args)
    {
        Bullet bullet = new Bullet(25);

        Enemy enemy = new Enemy(40);
        BreakableWall wall = new BreakableWall(30);

        Console.WriteLine("=== Початок симуляції ===");

        bullet.HitTarget(enemy);
        bullet.HitTarget(wall);

        Console.WriteLine("=== Кінець симуляції ===");
    }
}
