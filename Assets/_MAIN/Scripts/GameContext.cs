using UniRx;

namespace AliasGPT
{
    public class GameContext
    {
        public ReactiveProperty<GameMode> SelectedGameMode { get; } = new(GameMode.SimpleTeams);
    }
}