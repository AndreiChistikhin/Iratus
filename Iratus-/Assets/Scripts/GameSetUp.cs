using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetUp : MonoBehaviour
{
    [SerializeField] private HeroView[] _heroView;
    [SerializeField] private BossView _bossView;

    private Presenter[] _heroPresenter;
    private Presenter _bossPresenter;

    private HeroModel[] _heroModels;
    private BossModel _bossModel;

    private void Awake()
    {
        _bossModel = new BossModel(new HeroModel(),5);
        _bossPresenter = new Presenter(_bossView, _bossModel);

        _heroModels = new HeroModel[_heroView.Length];
        for (int i = 0; i < _heroModels.Length; i++)
        {
            _heroModels[i] = new HeroModel();
        }

        _heroPresenter = new Presenter[_heroView.Length];
        for (int i = 0; i < _heroModels.Length; i++)
        {
            _heroPresenter[i] = new Presenter(_heroView[i],_heroModels[i]);
        }
    }

    private void OnEnable()
    {
        _bossPresenter.Enable();
        foreach(Presenter presenter in _heroPresenter)
        {
            presenter.Enable();
        }
    }

    private void OnDisable()
    {
        _bossPresenter.Disable();
        foreach (Presenter presenter in _heroPresenter)
        {
            presenter.Disable();
        }
    }
}
