using Zenject;

public class ProjectContextInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerStatsModel>().AsSingle().NonLazy();
    }
}