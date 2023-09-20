using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class PopupAnimator : MonoBehaviour, IWindowAnimator
{
    [SerializeField]
    private CanvasGroup _canvasGroup;
    
    [SerializeField] 
    private float _animationTime = 0.5f;

    [SerializeField]
    private float _minAlpha = 0.3f;

    [SerializeField]
    private float _maxScale = 1.2f;
    
    public UniTask AnimateShow()
    {
        _canvasGroup.alpha = _minAlpha;
        transform.localScale = Vector3.one * _maxScale;
        
        var tcs = new UniTaskCompletionSource<bool>();

        var sequence = DOTween.Sequence();

        sequence.Append(_canvasGroup.DOFade(1, _animationTime))
                .Join(transform.DOScale(Vector3.one, _animationTime))
                .SetEase(Ease.OutExpo);

        //Debug.Log("Start show animation");
        return UniTask.Delay(TimeSpan.FromSeconds(_animationTime));
    }

    public UniTask AnimateHide()
    {
        _canvasGroup.alpha = 1;
        transform.localScale = Vector3.one;
        
        var tcs = new UniTaskCompletionSource<bool>();

        var sequence = DOTween.Sequence();

        sequence.Append(_canvasGroup.DOFade(_minAlpha, _animationTime))
                .Join(transform.DOScale(Vector3.one * _maxScale, _animationTime))
                .SetEase(Ease.OutExpo);

        //Debug.Log("Start show animation");
        return UniTask.Delay(TimeSpan.FromSeconds(_animationTime));
    }
}