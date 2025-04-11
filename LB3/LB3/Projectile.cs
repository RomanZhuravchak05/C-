public abstract class Projectile
{
    protected int damage;

    public Projectile(int damage)
    {
        this.damage = damage;
    }

    public abstract void HitTarget(IDamageable target);
}

