using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartGameButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    
    [Inject]
    private readonly StartGameCommand _startGameCommand;

    private void Awake()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _startGameCommand.Execute();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }
}