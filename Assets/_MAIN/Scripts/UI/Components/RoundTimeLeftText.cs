using AliasGPT;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class RoundTimeLeftText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [Inject]
    private GameContext _gameContext;

    private void Awake() => 
        _gameContext.RoundTimeLeft.Subscribe(OnLastRoundChanged).AddTo(this);

    private void OnLastRoundChanged(uint timeLeft) => 
        _text.text = timeLeft.ToString();
}