using AliasGPT;
using UniRx;
using UnityEngine;
using Zenject;

public class IsLastRoundToggle : MonoBehaviour
{
    [SerializeField]
    private bool _activateOnLast;

    [Inject]
    private GameContext _gameContext;

    private void Awake() => 
        _gameContext.IsLastRound.Subscribe(OnLastRoundChanged).AddTo(this);

    private void OnLastRoundChanged(bool isLastRound)
    {
        var activate = _activateOnLast == isLastRound;
        
        gameObject.SetActive(activate);
    }
}