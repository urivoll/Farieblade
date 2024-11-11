using Core.InGame.Controller;
using Core.InGame.Model;
using Core.InGame.Utils;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ModelInGameInstaller : MonoInstaller
    {
        [SerializeField] private Factory _factoryModel;
        [SerializeField] private SoundModel _soundModel;

        public override void InstallBindings()
        {
            Container.Bind<TurnModel>().AsSingle();
            Container.Bind<UnitCoordinatorModel>().AsSingle();
            Container.Bind<PlayerModel>().AsSingle();
            Container.Bind<AiModel>().AsSingle();
            Container.Bind<Factory>().FromInstance(_factoryModel).AsSingle();
            Container.Bind<SoundModel>().FromInstance(_soundModel).AsSingle();
        }
    }
}
