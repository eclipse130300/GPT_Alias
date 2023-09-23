using AliasGPT;
using TMPro;
using UnityEngine;
using Zenject;

public class WordsAmountInputField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;
    
    [Inject]
    private GameContext _gameContext;

    private void Awake() => 
        _inputField.onEndEdit.AddListener(OnRoundTimeChanged);

    private void OnDestroy() => 
        _inputField.onEndEdit.RemoveListener(OnRoundTimeChanged);

    private void OnEnable() => 
        _inputField.text = _gameContext.WordsAmount.Value.ToString();

    private void OnRoundTimeChanged(string wordsAmount) => 
        _gameContext.WordsAmount.Value = (uint)int.Parse(wordsAmount);
}