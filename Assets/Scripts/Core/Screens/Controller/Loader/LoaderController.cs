using Cysharp.Threading.Tasks;
using Data;
using Events;
using Zenject;

namespace Core.Controller.Loading
{
    public class LoaderController : EventDispatcher
    {
/*        private LoaderView _loaderView;
        private MessageBoxController _messageBoxController;
        private LoaderView.Factory _loaderViewsFactory;
        private AppVersionModel _loaderModel;

        private MainModel _mainModel;
        private ProductDataModel _productDataModel;
        private CartModel _cartModel;
        private OrderDataModel _orderDataModel;*/
        private UserData _userData;

        public async void Open()
        {
/*            _loaderView = _loaderViewsFactory.Create();
            var versionPass = await _loaderModel.VersionPass();
            if (!versionPass)
            {
                ShowVersionOldUI();
                return;
            }
            //bool haveReg = await _userData.CheckAccount();
            await LoadData();
            AppInitially(haveReg);*/
        }

        public async UniTask LoadData()
        {
/*            _cartModel.LoadOrderModels();
            await _mainModel.LoadMainModels();*/
            if (_userData.UserEverCreated()) 
            {
/*                await _productDataModel.LoadProductData(_userData.User.Id);
                _orderDataModel.ChangeFields(
                    _userData.User.Name, 
                    _userData.User.Street, 
                    _userData.User.House, 
                    _userData.User.Entrance,
                    _userData.User.Apartment, 
                    _userData.User.Phone, 
                    _userData.User.Floor, 
                    Payment.Наличными.ToString(), 
                    _userData.User.Domofon, 
                    string.Empty);*/
            }
        }

/*        private void ShowVersionOldUI()
        {
            _messageBoxController.OpenPopUpBlock(_messageBoxController.DefaultAttention, "Версия вашего приложения устарела!", "Скачать новую версию.");
        }

        private void AppInitially(bool value)
        {
            DispatchEvent(EventManager.AppInitially, value);
        }

        public void Close()
        {
            _loaderView.OnDestroy();
        }*/
    }
}