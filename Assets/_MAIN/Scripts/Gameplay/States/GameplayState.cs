using AliasGPT;
using DG.Tweening;

public class GameplayState : IState
{
    private readonly GameContext _gameContext;
    private readonly StateMachine _stateMachine;
    private readonly WordsProvider _wordsProvider;
    private readonly PopupsManager _popupsManager;

    public GameplayState(GameContext gameContext, StateMachine stateMachine, WordsProvider wordsProvider, PopupsManager popupsManager)
    {
        _gameContext = gameContext;
        _stateMachine = stateMachine;
        _wordsProvider = wordsProvider;
        _popupsManager = popupsManager;
    }

    public async void Enter()
    {
        _wordsProvider.SetNextWord();
        await _popupsManager.ShowPopup<GameplayWindow>();
        UpdateTime();
    }

    public void Exit()
    {
        DOTween.Kill(this);
    }

    private void UpdateTime() =>
        DOTween
           .To(() => _gameContext.RoundTimeLeft.Value, x => _gameContext.RoundTimeLeft.Value = x, 0, _gameContext.RoundTime.Value)
           .ChangeStartValue(_gameContext.RoundTime.Value)
           .SetEase(Ease.Linear)
           .SetId(this)
           .OnComplete(FinishRound);

    private void FinishRound() => 
        _stateMachine.EnterState<RoundFinishedState>();
}