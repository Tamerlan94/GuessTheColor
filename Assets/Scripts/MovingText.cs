using DG.Tweening;
using UnityEngine;

public class MovingText : MonoBehaviour
{
    private RectTransform _rect;
    private void Start()
    {
        _rect = GetComponent<RectTransform>();
        _rect.DOAnchorPosY(500f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
