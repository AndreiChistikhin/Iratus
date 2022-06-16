using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private List<MinerView> _unsortedMiners;

    private List<MinerView> _sortedMiners;

    public static event Action<MinerView> ActiveHeroChosen;

    private void Start()
    {
        _sortedMiners = new List<MinerView>();
        RandomlySortList();
        EnableActiveHero();
    }

    private void OnEnable()
    {
        ActionBar.TurnMoved += EnableActiveHero;
        MinerView.Died += RemoveHero;
    }

    private void OnDisable()
    {
        ActionBar.TurnMoved -= EnableActiveHero;
        MinerView.Died -= RemoveHero;
    }

    private void RandomlySortList()
    {
        while(_unsortedMiners.Count>0)
        {
            int randomIndex = Random.Range(0, _unsortedMiners.Count);
            MinerView miner = _unsortedMiners[randomIndex];
            _sortedMiners.Add(miner);
            _unsortedMiners.Remove(miner);
        }
    }

    private void EnableActiveHero()
    {
        if (_sortedMiners.Count <= 0) RandomlySortList();
        MinerView activeMiner = _sortedMiners[0];
        ActiveHeroChosen?.Invoke(activeMiner);
        _sortedMiners.Remove(activeMiner);
        _unsortedMiners.Add(activeMiner);
    }

    private void RemoveHero(MinerView miner)
    {
        if (_unsortedMiners.Contains(miner))
        {
            _unsortedMiners.Remove(miner);
            return;
        }
        _sortedMiners.Remove(miner);
    }
}
