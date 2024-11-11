using Core.Screens.Model.City;
using Data;
using UI.Manager;
using Zenject;

namespace Installers
{
    public class ModelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CityModel>().AsSingle();
            Container.Bind<UserData>().AsSingle();

            Container.Bind<AlchemyModel>().AsSingle();
            Container.Bind<DealerModel>().AsSingle();
            Container.Bind<TavernModel>().AsSingle();
        }
    }
}
