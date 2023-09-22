using AliasGPT;

public class InitGameplayState : IState
{
    private readonly GameContext _gameContext;
    private readonly StateMachine _stateMachine;

    public InitGameplayState(GameContext gameContext, StateMachine stateMachine)
    {
        _gameContext = gameContext;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _gameContext.CurrentRound.Value = 1;
        _gameContext.UsedWords.Clear();
        
        _stateMachine.EnterState<RoundPreparationState>();
    }

    public void Exit()
    {
        
    }
}