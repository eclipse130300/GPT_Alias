using AliasGPT;

public class GameSettings
{
    public GameMode Mode;
    public string Theme;
    public uint RoundTime;
    public uint MaxRounds;
    public uint WordsAmount;
    
    public GameSettings(GameMode mode, string theme, uint roundTime, uint maxRounds, uint wordsAmount)
    {
        Mode = mode;
        Theme = theme;
        RoundTime = roundTime;
        MaxRounds = maxRounds;
        WordsAmount = wordsAmount;
    }
    
    public static GameSettings Default => new(GameMode.SimpleTeams, "Общая тема", 60, 12, 40);
}