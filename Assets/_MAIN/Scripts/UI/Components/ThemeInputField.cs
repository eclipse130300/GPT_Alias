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
        _gameContext.CommonThemeName.Subscribe(OnThemeChanged).AddTo(this);

    private void OnThemeChanged(string themeName) => 
        _inputField.text = themeName;
}