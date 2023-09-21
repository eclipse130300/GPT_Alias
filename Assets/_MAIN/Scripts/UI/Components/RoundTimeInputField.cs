using AliasGPT;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class RoundTimeInputField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;
    
    [Inject]
    private GameContext _gameContext;

    private void Awake() => 
        _gameContext.RoundTime.Subscribe(OnThemeChanged).AddTo(this);

    private void OnThemeChanged(uint time) => 
        _inputField.text = time.ToString();
}