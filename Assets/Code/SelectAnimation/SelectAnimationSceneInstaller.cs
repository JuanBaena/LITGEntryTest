using Zenject;
using UnityEngine;

public class SelectAnimationSceneInstaller : MonoInstaller
{
    //View
    [SerializeField]
    private PlayerView playerView;

    //Presenters
    [SerializeField]
    private AnimationsScreenPresenter animationsScreenPresenter;

    //UseCases
    [SerializeField]
    private SelectAnimationUseCases playerUseCases;

    public override void InstallBindings()
    {
        //Injection
        Container
            .Bind<IPlayerView>()
            .FromInstance(playerView)
            .AsSingle();
        Container
            .Bind<IAnimationsScreenPresenter>()
            .FromInstance(animationsScreenPresenter)
            .AsSingle();
        Container
            .Bind<ISelectAnimationUseCases>()
            .FromInstance(playerUseCases)
            .AsSingle();
    }
}
