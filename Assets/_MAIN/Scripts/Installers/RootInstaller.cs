using AliasGPT;
using UnityEngine;
using Zenject;

public class RootInstaller : MonoInstaller<RootInstaller>
{
    [SerializeField] private Transform _uiRoot;
    
    public override void InstallBindings()
    {

    }
}