using System;
using AliasGPT;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ClosePopupButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    [SerializeField]
    private BaseWindow _window;

    [Inject] private PopupsManager _windowManager;
    private void Awake() => 
        _button.onClick.AddListener(OnButtonClick);

    private void OnButtonClick() => 
        _windowManager.HidePopup(_window);

    private void OnDestroy() => 
        _button.onClick.RemoveListener(OnButtonClick);
}