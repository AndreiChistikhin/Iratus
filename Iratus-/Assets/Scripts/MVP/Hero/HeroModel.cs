using System;

public class HeroModel : IDamageable
{
    private readonly int _maxHealth=100;
    private readonly int _minDamage = 5;
    private readonly int maxDamage = 15;

    private int _currentHealth = 100;

    public event Action Died;
    public event Action<int> DamageDone;
    public event Action<float,int> DamageTaken;

    public void DoDamage(int damageFactor)
    {
        Random random = new Random();
        int randomDamage = random.Next(_minDamage, maxDamage* damageFactor);
        DamageDone?.Invoke(randomDamage);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0) return;
        _currentHealth -= damage;
        if (_currentHealth < 0)
        {
            Died.Invoke();
            return;
        }
        float healthPercentage = (float)_currentHealth / _maxHealth;
        DamageTaken?.Invoke(healthPercentage,damage);
    }
}
