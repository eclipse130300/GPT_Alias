using System;
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
        _inputField.onEndEdit.AddListener(OnRoundTimeChanged);

    private void OnDestroy() => 
        _inputField.onEndEdit.RemoveListener(OnRoundTimeChanged);

    private void OnEnable() => 
        _inputField.text = _gameContext.RoundTime.Value.ToString();

    private void OnRoundTimeChanged(string roundTime) => 
        _gameContext.RoundTime.Value = (uint)int.Parse(roundTime);
}