using System;
using AliasGPT;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class PointsLastRoundText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    [Inject]
    private GameContext _gameContext;

    private void Awake()
    {
        _gameContext.AnsweredThisRound.ObserveCountChanged(true).Subscribe(OnCountChanged).AddTo(this);
        _gameContext.SkippedThisRound.ObserveCountChanged(true).Subscribe(OnCountChanged).AddTo(this);
    }
    
    private void OnCountChanged(int count)
    {
        var correctWords = _gameContext.AnsweredThisRound.Count;
        var wrongWords = _gameContext.SkippedThisRound.Count;

        var result = correctWords - wrongWords;
        bool isPositive = result > 0;
        
        var sign = isPositive ? "+" : "";

        _text.text = $"{sign}{result}";
    }
}