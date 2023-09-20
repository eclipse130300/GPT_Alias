using System;
using AliasGPT;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShowPopupButton<T> : MonoBehaviour where T : BaseWindow
{
    [SerializeField]
    private Button _button;

    [Inject] private PopupsManager _windowManager;
    private void Awake() => 
        _button.onClick.AddListener(OnButtonClick);

    private void OnButtonClick() => 
        _windowManager.ShowPopup<T>();

    private void OnDestroy() => 
        _button.onClick.RemoveListener(OnButtonClick);
}