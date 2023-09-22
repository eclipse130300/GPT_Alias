using AliasGPT;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class CurrentRoundText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [Inject]
    private GameContext _gameContext;

    private void Awake() => 
        _gameContext.CurrentRound.Subscribe(OnLastRoundChanged).AddTo(this);

    private void OnLastRoundChanged(uint currentRound) => 
        _text.text = $"{currentRound}/{_gameContext.MaxRounds}";
}