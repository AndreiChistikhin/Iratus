public class Presenter
{
    private MinerView _view;
    private IDamageable _model;
    private MinerView _targetView;

    public Presenter(MinerView view, IDamageable model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        HeroModel heroModel = _model as HeroModel;
        if(heroModel!=null)
        {
            Subscribe(heroModel);
        }
        BossModel bossModel = _model as BossModel;
        if (bossModel == null) return;
        Subscribe(bossModel.Hero);
    }

    private void Subscribe(HeroModel heroModel)
    {
        heroModel.Died += OnDie;
        heroModel.DamageDone += DoDamage;
        heroModel.DamageTaken += AdjustHealth;
        _view.Damaged += TakeDamage;
        _view.StartAtack += StartAttack;
    }

    public void Disable()
    {
        HeroModel heroModel = _model as HeroModel;
        if (heroModel != null)
        {
            Unsubscribe(heroModel);
        }
        BossModel bossModel = _model as BossModel;
        if (bossModel == null) return;
        Unsubscribe(bossModel.Hero);
    }

    private void Unsubscribe(HeroModel heroModel)
    {
        heroModel.Died -= OnDie;
        heroModel.DamageDone -= DoDamage;
        heroModel.DamageTaken -= AdjustHealth;
        _view.Damaged -= TakeDamage;
        _view.StartAtack -= StartAttack;
    }

    private void OnDie()
    {
        _view.DestroyMiner();
    }

    private void AdjustHealth(float healthPercentage, int damage)
    {
        _view.ControlHealth(healthPercentage, damage);
    }

    private void TakeDamage(int damage)
    {
        _model.TakeDamage(damage);
    }

    private void DoDamage(int damage)
    {
        _targetView.TakeDamage(damage);
    }

    private void StartAttack(MinerView targetMiner)
    {
        _targetView = targetMiner;
        _model.DoDamage(1);
    }
}
