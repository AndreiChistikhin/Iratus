public class BossModel : IDamageable
{
    private readonly int _bossDamageMultiplier=5;
    private readonly int _armor;
    private HeroModel _hero;

    public HeroModel Hero => _hero;

    public BossModel(HeroModel hero,int armor)
    {
        _hero = hero;
        _armor = armor;
    }

    public void DoDamage(int damageFactor)
    {
        _hero.DoDamage(_bossDamageMultiplier);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0) return;
        _hero.TakeDamage(damage - _armor);
    }
}
