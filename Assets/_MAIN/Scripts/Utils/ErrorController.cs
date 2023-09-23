using System;
using DG.Tweening;
using UnityEngine;

public class ErrorController : MonoBehaviour
{
    public static ErrorController Instance;
    
    [SerializeField]
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        
        
        _canvasGroup.alpha = 0;
    }

    public void ShowError()
    {
        Debug.LogError("Error occured!");
        DOTween.Kill(this);
        
        var sequence = DOTween.Sequence();
        
        sequence.Append(_canvasGroup.DOFade(1, 0.5f))
                .AppendInterval(1)
                .Append(_canvasGroup.DOFade(0, 0.5f))
                .SetId(this);
    }
}
