using AliasGPT;
using Cysharp.Threading.Tasks;

public class RoundFinishedState : IState
{
    private readonly PopupsManager _popupsManager;

    public RoundFinishedState(PopupsManager popupsManager)
    {
        _popupsManager = popupsManager;
    }

    public void Enter()
    {
        _popupsManager.ShowPopup<GameplayFinishedWindow>().Forget();
    }

    public void Exit()
    {
    }
}