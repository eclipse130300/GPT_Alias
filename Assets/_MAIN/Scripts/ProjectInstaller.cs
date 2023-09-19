using AliasGPT;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField]
    private LoadingCurtain _loadingCurtain;
    public override void InstallBindings()
    {
        var curtain = Instantiate(_loadingCurtain);
        Container.Bind<LoadingCurtain>().FromInstance(curtain);

        Container.Bind<IInstantiator>().FromInstance(Container);
    }
}
