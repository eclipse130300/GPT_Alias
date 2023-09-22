using AliasGPT;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    /*[SerializeField]
    private LoadingCurtain _loadingCurtain;*/
    
    [SerializeField]
    private Transform _uiRoot;

    public override void InstallBindings()
    {
        /*var curtain = Instantiate(_loadingCurtain);
        Container.Bind<LoadingCurtain>().FromInstance(curtain);*/

        Container.Bind<Transform>().FromInstance(_uiRoot).AsSingle().WhenInjectedInto<PopupsManager>().NonLazy();
        Container.Bind<PopupsManager>().AsSingle().NonLazy();
        
        Container.Bind<GameContext>().AsSingle().NonLazy();
        Container.Bind<StartGameCommand>().AsSingle().NonLazy();

        Container.Bind<GameBootstrapper>().AsSingle().NonLazy();
        Container.Bind<GameplayController>().AsSingle().NonLazy();
        Container.Bind<WordsProvider>().AsSingle().NonLazy();
    }
}
