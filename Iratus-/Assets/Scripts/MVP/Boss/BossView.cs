using UnityEngine.UI;
using UnityEngine;

public class BossView : MinerView
{
    [SerializeField] private ActionBar _actionBar;

    private void TryAtack()
    {
        if (!_actionBar.IsAtacking) return;
        _actionBar.AttackingMiner.SetTarget(this);
        _actionBar.AttackingMiner.Attack();
        _actionBar.MoveNextTurn();
    }

    private void OnMouseDown()
    {
        TryAtack();
    }
}
