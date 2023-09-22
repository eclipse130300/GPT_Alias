using AliasGPT;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class ThemeText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [Inject]
    private GameContext _gameContext;

    private void Awake() => 
        _gameContext.CommonThemeName.Subscribe(OnLastRoundChanged).AddTo(this);

    private void OnLastRoundChanged(string themeName) => 
        _text.text = themeName;
}