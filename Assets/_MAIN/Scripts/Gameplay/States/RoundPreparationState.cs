using AliasGPT;
using Cysharp.Threading.Tasks;

public class RoundPreparationState : IState
{
    private GameContext _gameContext;
    private PopupsManager _popupsManager;

    public void Enter()
    {
        _gameContext.RoundTimeLeft.Value = _gameContext.RoundTime.Value;
        _gameContext.AnsweredThisRound.Clear();
        _gameContext.SkippedThisRound.Clear();
        
        //get new word for next round
        
        _popupsManager.ShowPopup<GamePreparationWindow>().Forget();
    }

    public void Exit()
    {
        
    }
}