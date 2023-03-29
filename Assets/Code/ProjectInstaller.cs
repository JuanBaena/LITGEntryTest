using Zenject;
using UnityEngine;
class ProjectInstaller: MonoInstaller
{
    public override void InstallBindings()
    {
        //Preferences
        var playerPreferences = new PlayerPreferences();
        Container
            .Bind<IPlayerPreferences>()
            .FromInstance(playerPreferences)
            .AsSingle();

    }
}
