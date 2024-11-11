using Core.InGame.Utils;
using Zenject;

namespace Installers
{
    public class OtherSceneInGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MeleeAttack>().AsSingle();
            Container.Bind<ShooterAttack>().AsSingle();
            Container.Bind<GameSpeed>().AsSingle();
        }
    }
}
