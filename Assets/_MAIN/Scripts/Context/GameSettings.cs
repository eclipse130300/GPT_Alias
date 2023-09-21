using AliasGPT;

public class GameSettings
{
    public GameMode Mode;
    public string Theme;
    public uint RoundTime;
    public uint MaxRounds;
    
    public GameSettings(GameMode mode, string theme, uint roundTime, uint maxRounds)
    {
        Mode = mode;
        Theme = theme;
        RoundTime = roundTime;
        MaxRounds = maxRounds;
    }
    
    public static GameSettings Default => new(GameMode.SimpleTeams, "Общая тема", 60, 12);
}