using System;
using AliasGPT;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class RoundsAmountInputFiled : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;
    
    [Inject]
    private GameContext _gameContext;

    private void Awake() => 
        _inputField.onEndEdit.AddListener(OnRoundAmountChanged);

    private void OnDestroy() => 
        _inputField.onEndEdit.RemoveListener(OnRoundAmountChanged);

    private void OnEnable() => 
        _inputField.text = _gameContext.MaxRounds.Value.ToString();

    private void OnRoundAmountChanged(string maxRounds) => 
        _gameContext.MaxRounds.Value = (uint)int.Parse(maxRounds);
}