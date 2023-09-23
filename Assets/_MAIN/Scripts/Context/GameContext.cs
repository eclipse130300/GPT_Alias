using System.Collections.Generic;
using UniRx;

namespace AliasGPT
{
    public class GameContext
    {
        public GameContext()
        {
            var defaultSettings = GameSettings.Default;
            
            SelectedGameMode.Value = defaultSettings.Mode;
            CommonThemeName.Value = defaultSettings.Theme;
            RoundTime.Value = defaultSettings.RoundTime;
            MaxRounds.Value = defaultSettings.MaxRounds;
            WordsAmount.Value = defaultSettings.WordsAmount;
        }
        
        public GameContext(GameSettings gameSettings)
        {
            SelectedGameMode.Value = gameSettings.Mode;
            CommonThemeName.Value = gameSettings.Theme;
            RoundTime.Value = gameSettings.RoundTime;
            MaxRounds.Value = gameSettings.MaxRounds;
            WordsAmount.Value = gameSettings.WordsAmount;
        }

        public ReactiveProperty<GameMode> SelectedGameMode { get; } = new(GameMode.SimpleTeams);
        
        //public ReactiveProperty<bool> CommonThemeForEveryone { get; } = new(false);
        
        public ReactiveProperty<string> CommonThemeName { get; } = new("Общая тема");
        
        public ReactiveProperty<uint> WordsAmount { get; } = new(40);
        public ReactiveProperty<uint> RoundTime { get; } = new(60);
        
        public ReactiveProperty<uint> RoundTimeLeft { get; } = new(60);
        
        public ReactiveProperty<uint> MaxRounds { get; } = new(12);

        public ReactiveProperty<bool> IsLastRound { get; } = new(false);

        public ReactiveProperty<uint> CurrentRound { get; } = new(1);

        public ReactiveCollection<string> AnsweredThisRound { get; } = new();

        public ReactiveCollection<string> SkippedThisRound { get; } = new();

        public ReactiveProperty<string> CurrentWord { get; } = new();

        //public ReactiveCollection<string> AllWords { get; } = new();

        //public ReactiveCollection<string> UsedWords { get; } = new();
    }
}