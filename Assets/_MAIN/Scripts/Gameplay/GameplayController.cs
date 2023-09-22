using System.Collections.Generic;
using AliasGPT;
using Cysharp.Threading.Tasks;

public class GameplayController
{
    private readonly StateMachine _stateMachine;
    private readonly PopupsManager _popupsManager;
    
    public GameplayController(PopupsManager popupsManager, GameContext gameContext, WordsProvider wordsProvider)
    {
        _popupsManager = popupsManager;
        
        _stateMachine = new StateMachine();

        var states = new List<IExitState>()
        {
            new InitGameplayState(gameContext, _stateMachine),
            new GameDisabledState(),
            new RoundPreparationState(gameContext, popupsManager),
            new GameplayState(gameContext, _stateMachine, wordsProvider),
            new RoundFinishedState(),
        };
        
        _stateMachine.Initialize(states);
        _stateMachine.EnterState<GameDisabledState>();
    }
    
    public void StartGameplayLoop()
    {
        _stateMachine.EnterState<InitGameplayState>();
    }

    public void QuitGameplayLoop()
    {
        _stateMachine.EnterState<GameDisabledState>();
        _popupsManager.ShowPopup<MainWindow>().Forget();
    }

    public void StartRound()
    {
        _stateMachine.EnterState<GameplayState>();
    }

    public void GoToNextRound()
    {
        _stateMachine.EnterState<RoundPreparationState>();
    }
}