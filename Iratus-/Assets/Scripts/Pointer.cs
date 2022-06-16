using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(MinerView))]
public class Pointer : MonoBehaviour
{
    [SerializeField] private Image _pointer;

    private void OnEnable()
    {
        Randomizer.ActiveHeroChosen += SetPointer;
    }

    private void OnDisable()
    {
        Randomizer.ActiveHeroChosen -= SetPointer;
    }

    private void SetPointer(MinerView miner)
    {
        if(miner==GetComponent<MinerView>())
        {
            _pointer.gameObject.SetActive(true);
        }
        else
        {
            _pointer.gameObject.SetActive(false);
        }
    }
}
