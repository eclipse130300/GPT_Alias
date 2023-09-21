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
        }
        
        public GameContext(GameSettings gameSettings)
        {
            SelectedGameMode.Value = gameSettings.Mode;
            CommonThemeName.Value = gameSettings.Theme;
            RoundTime.Value = gameSettings.RoundTime;
            MaxRounds.Value = gameSettings.MaxRounds;
        }

        public ReactiveProperty<GameMode> SelectedGameMode { get; } = new(GameMode.SimpleTeams);
        
        //public ReactiveProperty<bool> CommonThemeForEveryone { get; } = new(false);
        
        public ReactiveProperty<string> CommonThemeName { get; } = new("Общая тема");
        
        public ReactiveProperty<uint> RoundTime { get; } = new(60);
        
        public ReactiveProperty<uint> MaxRounds { get; } = new(12);
        
        public ReactiveProperty<uint> CurrentRound { get; } = new(1);

        public ReactiveCollection<string> AllWords { get; } = new();
        
        public ReactiveCollection<string> UsedWords { get; } = new();
        
        public List<string> AnsweredThisRound { get; } = new();
        
        public List<string> SkippedThisRound { get; } = new();
        
        public ReactiveProperty<string> CurrentWord { get; } = new();
    }
}