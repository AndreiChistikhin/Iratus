using UnityEngine.UI;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _healthImage;
    [SerializeField] private TMP_Text _damageAmount;

    public void AdjustHealth(float healthPercentage, int damage)
    {
        AdjustHealthAsync(healthPercentage, damage).Forget();
    }

    public async UniTask AdjustHealthAsync(float healthPercentage, int damage)
    {
        _healthImage.fillAmount = healthPercentage;
        _damageAmount.text = $"- {damage}";
        await _damageAmount.DOFade(1, 1).AsyncWaitForCompletion();
        _damageAmount.DOFade(0, 1);
    }
}
