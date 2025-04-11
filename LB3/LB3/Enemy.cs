using System;

public class Enemy : IDamageable
{
    private int health;

    public Enemy(int health)
    {
        this.health = health;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Console.WriteLine("Ворог отримав " + damage + " шкоди. Залишилось здоров’я: " + health);

        if (health <= 0)
        {
            Console.WriteLine("Ворог знищений!");
        }
    }
}
