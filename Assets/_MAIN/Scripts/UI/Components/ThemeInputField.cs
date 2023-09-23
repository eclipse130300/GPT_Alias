using System;
using AliasGPT;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class ThemeInputField : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;
    
    [Inject]
    private GameContext _gameContext;

    private void Awake() => 
        _inputField.onEndEdit.AddListener(OnThemeChanged);

    private void OnDestroy() => 
        _inputField.onEndEdit.RemoveListener(OnThemeChanged);

    private void OnEnable() => 
        _inputField.text = _gameContext.CommonThemeName.Value;

    private void OnThemeChanged(string themeName) => 
        _gameContext.CommonThemeName.Value = themeName;
}