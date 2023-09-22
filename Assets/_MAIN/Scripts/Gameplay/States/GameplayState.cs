using AliasGPT;
using DG.Tweening;

public class GameplayState : IState
{
    private readonly GameContext _gameContext;
    private readonly StateMachine _stateMachine;

    public GameplayState(GameContext gameContext, StateMachine stateMachine)
    {
        _gameContext = gameContext;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        UpdateTime();
    }

    public void Exit()
    {
        _stateMachine.EnterState<RoundFinishedState>();
    }

    private void UpdateTime() =>
        DOTween
           .To(() => _gameContext.RoundTimeLeft.Value, x => _gameContext.RoundTimeLeft.Value = x, 0, _gameContext.RoundTime.Value)
           .ChangeStartValue(_gameContext.RoundTime.Value)
           .SetEase(Ease.Linear)
           .OnComplete(Exit);
}