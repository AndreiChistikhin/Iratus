using UnityEngine;
using Spine.Unity;
using Spine;
using DG.Tweening;

public class MinerController : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation _minerSkeleton;
    [SerializeField] private AnimationReferenceAsset _idle, _damaged, _atack;
    [SerializeField] private MinerView _minerView;

    private TrackEntry _animationEntry;
    private float _initialXPosition;
    private readonly int _atackXPosition = 2;

    private void Start()
    {
        SetAnimation(_idle, true);
        _initialXPosition = transform.position.x;
    }

    private void SetAnimation(AnimationReferenceAsset animation, bool loop)
    {
        _animationEntry = _minerSkeleton.state.SetAnimation(0, animation, loop);
        if (animation.Equals(_idle)) return;
        _animationEntry.Complete += SetIdleAnimation;
    }

    private void SetIdleAnimation(TrackEntry trackEntry)
    {
        _minerSkeleton.state.SetAnimation(0, _idle, true);
        if (transform.position.x == _initialXPosition) return;
        transform.DOMoveX(_initialXPosition, 1);
    }

    public void SetAtackAnimation()
    {
        SetAnimation(_atack, false);
        transform.DOMoveX(_atackXPosition, 1);
    }

    public void SetDamagedAnimation()
    {
        SetAnimation(_damaged, false);
    }
}
