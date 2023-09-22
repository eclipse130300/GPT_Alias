using System.Collections.Generic;
using AliasGPT;

public class WordsProvider
{
    private GameContext _gameContext;
    private List<string> _allWords;
    
    private int _currentWordIndex = 0;

    public WordsProvider(GameContext gameContext)
    {
        _gameContext = gameContext;
    }
    
    public void Initialize(List<string> allWords)
    {
        _allWords = allWords;
        _currentWordIndex = 0;
    }
    
    public void SetNextWord()
    {
        var nextWord = _allWords[_currentWordIndex % _allWords.Count];
        _gameContext.CurrentWord.Value = nextWord;
        _currentWordIndex++;
    }
}