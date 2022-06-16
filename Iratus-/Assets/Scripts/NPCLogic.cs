using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class NPCLogic : MonoBehaviour
{
    [SerializeField] private List<MinerView>_heroes;
    [SerializeField] private MinerView _npc;
    [SerializeField] private ActionBar _actionBar;

    public static event Action<string> GameFinished;

    private void OnEnable()
    {
        Randomizer.ActiveHeroChosen += StartNPCAttack;
        MinerView.Died += RemoveHero;
    }

    private void OnDisable()
    {
        Randomizer.ActiveHeroChosen -= StartNPCAttack;
        MinerView.Died -= RemoveHero;
    }

    private void StartNPCAttack(MinerView miner)
    {
        DoNPCAttack(miner).Forget();
    }

    private async UniTask DoNPCAttack(MinerView miner)
    {
        if (miner is HeroView) return;
        await UniTask.Delay(1500);
        int randomIndex=Random.Range(0, _heroes.Count);
        _npc.SetTarget(_heroes[randomIndex]);
        _npc.Attack();
        _actionBar.MoveNextTurn();
    }

    private void OnDestroy()
    {
        GameFinished?.Invoke("You won");
    }

    private void RemoveHero(MinerView miner)
    {
        _heroes.Remove(miner);
        if (_heroes.Count == 0)
            GameFinished?.Invoke("You lost");
    }
}
