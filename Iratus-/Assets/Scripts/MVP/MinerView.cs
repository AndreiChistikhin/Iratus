using System;
using UnityEngine;

public class MinerView : MonoBehaviour
{
    [SerializeField] private HPBar _healthBar;
    [SerializeField] private MinerController _controller;

    private MinerView _minerToAttack;

    public event Action<int> Damaged;
    public event Action<MinerView> StartAtack;
    public static event Action<MinerView> Died;

    public void TakeDamage(int damage)
    {
        Damaged?.Invoke(damage);
        _controller.SetDamagedAnimation();
    }

    public void Attack()
    {
        StartAtack?.Invoke(_minerToAttack);
        _controller.SetAtackAnimation();
    }

    public void ControlHealth(float healthPercentage, int damage)
    {
        _healthBar.AdjustHealth(healthPercentage, damage);
    }

    public void DestroyMiner()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }

    public void SetTarget(MinerView miner)
    {
        _minerToAttack = miner;
    }
}
