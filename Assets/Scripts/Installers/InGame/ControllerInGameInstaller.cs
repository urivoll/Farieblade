using Core.InGame.Controller;
using Core.InGame.UI.Controller;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ControllerInGameInstaller : MonoInstaller
    {
        [SerializeField] private GameController _gameController;

        public override void InstallBindings()
        {
            Container.Bind<TurnController>().AsSingle();
            Container.Bind<BGController>().AsSingle();
            Container.Bind<CirclesController>().AsSingle();
            Container.Bind<UnitCoordinatorController>().AsSingle();
            Container.Bind<PlayerController>().AsSingle();
            Container.Bind<AiController>().AsSingle();
            Container.Bind<SoundController>().AsSingle();
            Container.Bind<GameController>().FromInstance(_gameController).AsSingle();
            //UI
            Container.Bind<SettingsController>().AsSingle();
            Container.Bind<BotSideController>().AsSingle();
        }
    }
}
