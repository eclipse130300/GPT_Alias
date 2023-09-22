using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class QuitGameplayButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    
    [Inject]
    private GameplayController _gameplayController;

    private void Awake() => 
        _button.onClick.AddListener(OnClick);

    private void OnClick() => 
        _gameplayController.QuitGameplayLoop();

    private void OnDestroy() => 
        _button.onClick.RemoveListener(OnClick);
}