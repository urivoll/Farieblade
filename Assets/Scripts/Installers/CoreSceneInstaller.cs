using Core.Screens.Controller.PopUp;
using Core.Screens.View.FooterMenu;
using Data;
using Server;
using UI.Manager;
using UI.Screens.PopUp;
using UI.UIElement;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CoreSceneInstaller : MonoInstaller
    {
        [SerializeField] private UIApp uiApp;
        [SerializeField] private MessageBoxInfo messageBoxInfo;
        [SerializeField] private MessageBoxDialog messageBoxDialog;
        [SerializeField] private MessageBoxNeutral messageBoxNeutral;
        [SerializeField] private PopUpNotification popUpNotification;
        [SerializeField] private PopUpAppVersionBlocker popUpAppVersionBlocker;
        [SerializeField] private FooterMenu _footerMenu;

        public override void InstallBindings()
        {
            Container.Bind<UIApp>().FromInstance(uiApp).AsSingle();
            Container.Bind<FooterMenu>().FromInstance(_footerMenu).AsSingle();

            Container.BindFactory<MessageBoxInfo, MessageBoxInfo.Factory>().FromComponentInNewPrefab(messageBoxInfo);
            Container.BindFactory<MessageBoxDialog, MessageBoxDialog.Factory>().FromComponentInNewPrefab(messageBoxDialog);
            Container.BindFactory<MessageBoxNeutral, MessageBoxNeutral.Factory>().FromComponentInNewPrefab(messageBoxNeutral);
            Container.BindFactory<PopUpNotification, PopUpNotification.Factory>().FromComponentInNewPrefab(popUpNotification);
            Container.BindFactory<PopUpAppVersionBlocker, PopUpAppVersionBlocker.Factory>().FromComponentInNewPrefab(popUpAppVersionBlocker);
           
            Container.Bind<MessageBoxController>().AsSingle();
            Container.Bind<RequestBuilder>().AsSingle();
        }
    }
}
