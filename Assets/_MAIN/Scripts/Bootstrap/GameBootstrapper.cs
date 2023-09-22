using System;
using AliasGPT;
using UnityEngine;
using Zenject;

public class GameBootstrapper
{
    private readonly PopupsManager _popupsManager;

    public GameBootstrapper(PopupsManager popupsManager)
    {
        _popupsManager = popupsManager;
        
        Bootstrap();
    }

    private async void Bootstrap()
    {
        //show loading curtain
        //show start window
        await _popupsManager.ShowPopup<MainWindow>();
        
        //hide curtain
    }
}