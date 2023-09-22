using AliasGPT;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WrongAnswerButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    
    private WordsProvider _wordsProvider;
    private GameContext _gameContext;

    [Inject]
    private void Construct(WordsProvider wordsProvider, GameContext gameContext)
    {
        _wordsProvider = wordsProvider;
        _gameContext = gameContext;
    }

    private void Awake() => 
        _button.onClick.AddListener(OnClick);

    private void OnClick()
    {
        _gameContext.SkippedThisRound.Add(_gameContext.CurrentWord.Value);
        _wordsProvider.SetNextWord();
    }

    private void OnDestroy() => 
        _button.onClick.RemoveListener(OnClick);
}