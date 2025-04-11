using System;

public class BreakableWall : IDamageable
{
    private int durability;

    public BreakableWall(int durability)
    {
        this.durability = durability;
    }

    public void TakeDamage(int damage)
    {
        durability -= damage;
        Console.WriteLine("Стіна отримала " + damage + " шкоди. Залишилась міцність: " + durability);

        if (durability <= 0)
        {
            Console.WriteLine("Стіна зруйнована!");
        }
    }
}
