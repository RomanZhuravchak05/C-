using System;

public class Bullet : Projectile
{
    public Bullet(int damage) : base(damage)
    {
    }

    public override void HitTarget(IDamageable target)
    {
        Console.WriteLine("Куля влучила у ціль і завдала " + damage + " шкоди.");
        target.TakeDamage(damage);
    }
}
