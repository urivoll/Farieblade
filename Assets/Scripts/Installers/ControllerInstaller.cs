using Core.Screens.Controller.Main;
using UI.Manager;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ControllerInstaller : MonoInstaller
    {
        [SerializeField] private AppController appController;

        public override void InstallBindings()
        {
            Container.Bind<CityController>().AsSingle();
            Container.Bind<AppController>().FromInstance(appController).AsSingle();

            Container.Bind<AlchemyController>().AsSingle();
            Container.Bind<DealerController>().AsSingle();
            Container.Bind<TavernController>().AsSingle();
        }
    }
}
