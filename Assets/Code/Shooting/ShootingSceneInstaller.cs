using Zenject;
using UnityEngine;

class ShootingSceneInstaller : MonoInstaller
{
    //View
    [SerializeField]
    private PlayerView miniaturePlayerView;
    [SerializeField]
    private PlayerView firstPersonPlayerView;
    [SerializeField]
    private PickingSystemController pickingSystemController;
    [SerializeField]
    private WeaponController weaponController;
    [SerializeField]
    private ShootingScreenPresenter shootingScreenPresenter;

    //UseCases
    [SerializeField]
    private ShootingUseCases shootingUseCases;

    public override void InstallBindings()
    {
        Container
            .Bind<IPlayerView>()
            .WithId("miniaturePlayerView")
            .FromInstance(miniaturePlayerView);
        Container
            .Bind<IPlayerView>()
            .WithId("firstPersonPlayerView")
            .FromInstance(firstPersonPlayerView);
        Container
            .Bind(typeof(IWeaponUseCases), typeof(IPlayerMovementUseCases))
            .FromInstance(shootingUseCases)
            .AsSingle();
        Container
            .Bind<IPickingSystemController>()
            .FromInstance(pickingSystemController)
            .AsSingle();
        Container
            .Bind<IWeaponController>()
            .FromInstance(weaponController)
            .AsSingle();
        Container
            .Bind<IShootingScreenPresenter>()
            .FromInstance(shootingScreenPresenter)
            .AsSingle();
    }
}
