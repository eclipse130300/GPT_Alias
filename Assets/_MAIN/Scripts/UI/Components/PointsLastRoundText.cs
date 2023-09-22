using System;
using AliasGPT;
using TMPro;
using UnityEngine;
using Zenject;

public class PointsLastRoundText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [Inject]
    private GameContext _gameContext;

    //make it reactive later!
    private void OnEnable()
    {
        var correctWords = _gameContext.AnsweredThisRound.Count;
        var wrongWords = _gameContext.SkippedThisRound.Count;

        var result = correctWords - wrongWords;
        bool isPositive = result > 0;
        
        var sign = isPositive ? "+" : "-";

        _text.text = $"{sign}{result}";
    }
}