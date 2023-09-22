using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GoToNextRoundButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    
    [Inject]
    private GameplayController _gameplayController;

    private void Awake() => 
        _button.onClick.AddListener(OnClick);

    private void OnClick() => 
        _gameplayController.GoToNextRound();

    private void OnDestroy() => 
        _button.onClick.RemoveListener(OnClick);
}