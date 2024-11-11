using Core.Controller.Loading;
using Core.Screens.Controller.Main;
using Core.Screens.View.FooterMenu;
using Events;
using UnityEngine;
using Zenject;

namespace UI.Manager
{
    public class AppController : EventBehaviour
    {
        private IController[] _controller = new IController[5];
        private LoaderController _loaderController;
        private FooterMenu _footerMenu;
        private int _currnentMenuInt;

        [Inject]
        private void Construct(
            CityController cityController)
        {
            _controller[0] = cityController;
        }

        private void Start()
        {
            _controller[0].Open();
        }
    }
}
public interface IController
{
    public void Open();
    public void Close();
}