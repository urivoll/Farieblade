using Events;
using Models;
using Zenject;

namespace UI.Manager
{
    public class ProfileManager : EventDispatcher
    { }
}
/*        private OrderManager _orderManager;
*//*        private ProfileScreenGarage _profileScreenGarage;
        private ProfileScreenMain _profileScreenMain;
        private ProfileScreenOrderList _profileScreenOrderList;
        private AboutScreen _aboutScreen;
        private SettingScreen _settingScreen;
        private SupportScreen _supportScreen;
        
        private ProfileScreenGarage.Factory _profileScreenGarageFactory;
        private ProfileScreenMain.Factory _profileScreenMainFactory;
        private ProfileScreenOrderList.Factory _profileScreenOrderListFactory;
        private AboutScreen.Factory _aboutScreenFactory;
        private SettingScreen.Factory _settingScreenFactory;
        private SupportScreen.Factory _supportScreenFactory;*//*

        [Inject]
        private void Construct(
            OrderManager orderManager,
*//*            ProfileScreenGarage.Factory profileScreenGarageFactory,
            ProfileScreenMain.Factory profileScreenMainFactory,
            ProfileScreenOrderList.Factory profileScreenOrderListFactory,
            AboutScreen.Factory aboutScreenFactory,
            SettingScreen.Factory settingScreenFactory,
            SupportScreen.Factory supportScreenFactory*//*
        )
        {
            _orderManager = orderManager;
*//*            _profileScreenGarageFactory = profileScreenGarageFactory;
            _profileScreenMainFactory = profileScreenMainFactory;
            _profileScreenOrderListFactory = profileScreenOrderListFactory;
            _aboutScreenFactory = aboutScreenFactory;
            _settingScreenFactory = settingScreenFactory;
            _supportScreenFactory = supportScreenFactory;*//*
        }

        public void Open()
        {     
*//*            _profileScreenMain = _profileScreenMainFactory.Create();
            _profileScreenMain.AddListener(ManagerEvents.CargoScreen, CargoScreen);
            _profileScreenMain.AddListener(ManagerEvents.TransportationScreen, TransportationScreen);
            _profileScreenMain.AddListener(ManagerEvents.GarageScreen, GarageScreen);
            _profileScreenMain.AddListener(ManagerEvents.SettingScreen, SettingScreen);
            _profileScreenMain.AddListener(ManagerEvents.AboutScreen, AboutScreen);
            _profileScreenMain.AddListener(ManagerEvents.SupportScreen, SupportScreen);
            _profileScreenMain.AddListener(ManagerEvents.OnClickBack, OnClickBack);*//*
        }
        
        private void CargoScreen(EventArgs evt)
        {
*//*            _profileScreenOrderList = _profileScreenOrderListFactory.Create();
            _profileScreenOrderList.AddListener(ManagerEvents.OnClickBack, OrderListByProfile);
            _profileScreenOrderList.Open(false, "Груз");*//*
            
            ProfileRemoveListener();
        }

        private void OrderListByProfile(EventArgs evt)
        {
*//*            _profileScreenOrderList.RemoveListener(ManagerEvents.OnClickBack, OrderListByProfile);
            _profileScreenOrderList.OnDestroy();*//*
            
            Open();
        }
        
        private void TransportationScreen(EventArgs evt)
        {
            _profileScreenOrderList = _profileScreenOrderListFactory.Create();
            _profileScreenOrderList.AddListener(ManagerEvents.OnClickBack, OrderListByProfile);
            _profileScreenOrderList.Open(false, "Транспорт");
            
            ProfileRemoveListener();
        }

        private void GarageScreen(EventArgs evt)
        {
            _profileScreenGarage = _profileScreenGarageFactory.Create();
            _profileScreenGarage.AddListener(ManagerEvents.OnClickBack, GarageByProfile);
            _profileScreenGarage.Open();
            
            ProfileRemoveListener();
        }

        private void GarageByProfile(EventArgs evt)
        {
            _profileScreenGarage.RemoveListener(ManagerEvents.OnClickBack, GarageByProfile);
            _profileScreenGarage.OnDestroy();
            
            Open();
        }

        private void SettingScreen(EventArgs evt)
        {
            _settingScreen = _settingScreenFactory.Create();
            _settingScreen.AddListener(ManagerEvents.OnClickBack, SettingByProfile);
            _settingScreen.AddListener(ManagerEvents.Logout, SettingLogout);
            _settingScreen.Open();
            
            ProfileRemoveListener();
        }

        private void SettingByProfile(EventArgs evt)
        {
            _settingScreen.RemoveListener(ManagerEvents.OnClickBack, SettingByProfile);
            _settingScreen.RemoveListener(ManagerEvents.Logout, SettingLogout);
            _settingScreen.OnDestroy();
            
            Open();
        }
        
        private void SettingLogout(EventArgs evt)
        {
            _settingScreen.RemoveListener(ManagerEvents.OnClickBack, SettingByProfile);
            _settingScreen.RemoveListener(ManagerEvents.Logout, SettingLogout);
            _settingScreen.OnDestroy();
            
            DispatchEvent(ManagerEvents.Logout);
        }

        private void AboutScreen(EventArgs evt)
        {
            _aboutScreen = _aboutScreenFactory.Create();
            _aboutScreen.AddListener(ManagerEvents.OnClickBack, AboutByProfile);
            
            ProfileRemoveListener();
        }

        private void AboutByProfile(EventArgs evt)
        {
            _aboutScreen.RemoveListener(ManagerEvents.OnClickBack, AboutByProfile);
            _aboutScreen.OnDestroy();
            
            Open();
        }

        private void SupportScreen(EventArgs evt)
        {
            _supportScreen = _supportScreenFactory.Create();
            _supportScreen.AddListener(ManagerEvents.OnClickBack, SupportByProfile);
            
            ProfileRemoveListener();
        }

        private void SupportByProfile(EventArgs evt)
        {
            _supportScreen.RemoveListener(ManagerEvents.OnClickBack, SupportByProfile);
            _supportScreen.OnDestroy();
            
            Open();
        }

        private void OnClickBack(EventArgs evt)
        {
            DispatchEvent(ManagerEvents.OnClickBack);
            
            ProfileRemoveListener();
        }
        
        private void ProfileRemoveListener()
        {
            _profileScreenMain.RemoveListener(ManagerEvents.CargoScreen, CargoScreen);
            _profileScreenMain.RemoveListener(ManagerEvents.TransportationScreen, TransportationScreen);
            _profileScreenMain.RemoveListener(ManagerEvents.GarageScreen, GarageScreen);
            _profileScreenMain.RemoveListener(ManagerEvents.SettingScreen, SettingScreen);
            _profileScreenMain.RemoveListener(ManagerEvents.AboutScreen, AboutScreen);
            _profileScreenMain.RemoveListener(ManagerEvents.SupportScreen, SupportScreen);
            _profileScreenMain.RemoveListener(ManagerEvents.OnClickBack, OnClickBack);
            
            _profileScreenMain.OnDestroy();
        }
    }*/

