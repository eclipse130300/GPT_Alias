using AliasGPT;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class CurrentWordText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [Inject]
    private GameContext _gameContext;

    private void Awake() => 
        _gameContext.CurrentWord.Subscribe(OnLastRoundChanged).AddTo(this);

    private void OnLastRoundChanged(string currentWord) => 
        _text.text = currentWord;
}