using Core.InGame.View;
using Zenject;
using EventDispatcher = Events.EventDispatcher;

namespace Core.InGame.Controller
{
    public class BGController : EventDispatcher
    {
        [Inject] private BGView _bgView;

        public void Open(int index = -1)
        {
            _bgView.Open(index);
        }
    }
}
