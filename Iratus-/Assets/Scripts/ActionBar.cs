using UnityEngine.UI;
using UnityEngine;
using System;

public class ActionBar : MonoBehaviour
{
    [SerializeField] private Button _atackButton;
    [SerializeField] private Button _skipButton;
    [SerializeField] private Texture2D _atackCursor;


    public MinerView AttackingMiner { get; private set; }
    public bool IsAtacking { get; private set; }

    public static event Action TurnMoved;

    private void OnEnable()
    {
        _atackButton.onClick.AddListener(EnableAtackSign);
        _skipButton.onClick.AddListener(MoveNextTurn);
        Randomizer.ActiveHeroChosen += SetActiveMiner;
    }

    private void OnDisable()
    {
        _atackButton.onClick.RemoveListener(EnableAtackSign);
        _skipButton.onClick.RemoveListener(MoveNextTurn);
        Randomizer.ActiveHeroChosen -= SetActiveMiner;
    }

    private void EnableAtackSign()
    {
        Cursor.SetCursor(_atackCursor, Vector2.zero, CursorMode.ForceSoftware);
        IsAtacking = true;
    }

    public void MoveNextTurn()
    {
        IsAtacking = false;
        TurnMoved?.Invoke();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void SetActiveMiner(MinerView miner)
    {
        if (miner is BossView) return;
        AttackingMiner = miner;
    }
}
