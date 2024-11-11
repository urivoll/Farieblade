using Core.InGame.UI.Controller;
using Core.InGame.UI.View;
using Core.InGame.View;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ViewInGameInstaller : MonoInstaller
    {
        [SerializeField] private BGView _bgView;
        [SerializeField] private CirclesView _circlesView;
        [SerializeField] private SettingsView _settingsView;
        [SerializeField] private BotSideView _botSideView;

        public override void InstallBindings()
        {
            Container.Bind<BGView>().FromInstance(_bgView).AsSingle();
            Container.Bind<CirclesView>().FromInstance(_circlesView).AsSingle();
            //UI
            Container.Bind<SettingsView>().FromInstance(_settingsView).AsSingle();
            Container.Bind<BotSideView>().FromInstance(_botSideView).AsSingle();
            //Container.BindFactory<AlchemyView, AlchemyView.Factory>().FromComponentInNewPrefab(_alchemyView);
        }
    }
}
