using Events;
using Models;
using Server;
using Zenject;
using EventArgs = Events.EventArgs;

namespace UI.Manager
{
    public class OrderManager : EventDispatcher
    {
        /*private OrderModel _currentOrder;
        
        private RequestBuilder _requestBuilder;
        private MessageBoxManager _messageBoxManager;
        private ProfileScreenOrderList _profileScreenOrderList;
        private ProfileScreenOrderList.Factory _profileScreenOrderListFactory;

        [Inject]
        private void Construct(
            RequestBuilder requestBuilder,
            MessageBoxManager messageBoxManager,
            ProfileScreenOrderList.Factory profileScreenOrderListFactory
        )
        {
            _requestBuilder = requestBuilder;
            _messageBoxManager = messageBoxManager;
            _profileScreenOrderListFactory = profileScreenOrderListFactory;
        }

        public void Open(OrderModel orderModel)
        {
            _currentOrder = orderModel;
            
            if (orderModel.State == "Груз")
            {
                TransportationScreen();
            }
            if (orderModel.State == "Транспорт")
            {
                CargoScreen();
            }
        }
        
        private void CargoScreen()
        {
            _profileScreenOrderList = _profileScreenOrderListFactory.Create();
            _profileScreenOrderList.AddListener(ManagerEvents.OnClickBack, OrderListByProfile);
            _profileScreenOrderList.AddListener(ManagerEvents.SendOrder, SendOrderOrderList);
            _profileScreenOrderList.Open(true, "Груз");

        }

        private void OrderListByProfile(EventArgs evt)
        {
            _profileScreenOrderList.RemoveListener(ManagerEvents.OnClickBack, OrderListByProfile);
            _profileScreenOrderList.RemoveListener(ManagerEvents.SendOrder, SendOrderOrderList);
            _profileScreenOrderList.OnDestroy();
            DispatchEvent(ManagerEvents.OnClickBack);
        }

        private void SendOrderOrderList(EventArgs evt)
        {
            var sendOrder = evt.args[0] as OrderModel;
            _profileScreenOrderList.RemoveListener(ManagerEvents.OnClickBack, OrderListByProfile);
            _profileScreenOrderList.RemoveListener(ManagerEvents.SendOrder, SendOrderOrderList);
            _profileScreenOrderList.OnDestroy();
            SendOrder(sendOrder);
        }

        private void TransportationScreen()
        {
            _profileScreenOrderList = _profileScreenOrderListFactory.Create();
            _profileScreenOrderList.AddListener(ManagerEvents.OnClickBack, OrderListByProfile);
            _profileScreenOrderList.AddListener(ManagerEvents.SendOrder, SendOrderOrderList);
            _profileScreenOrderList.Open(true, "Транспорт");
        }

        
        private void SendOrder(OrderModel sendOrder)
        {
            if (sendOrder != null)
            {
                sendOrder.OrderState = "Заявка";
                sendOrder.OrderId = _currentOrder.Id;

                SaveAsync(sendOrder);
            }
        }
        
        private async void SaveAsync(OrderModel order)
        {
            var apiCallResult = await _requestBuilder.PutOrderModel(order);
            
            if (string.IsNullOrEmpty(apiCallResult.ErrorMessage) == false)
            {
                _messageBoxManager.OpenInfo(_messageBoxManager.DefaultErrorHeader, "Проблемы с соединением", () =>
                {
                    DispatchEvent(ManagerEvents.OnClickBack);
                });
                return;
            }

            _messageBoxManager.OpenInfo(_messageBoxManager.DefaultInfoHeader, "Ваша заявка успешно отправлена!", () =>
            {
                DispatchEvent(ManagerEvents.OnClickBack);
            });
        }
     */
        
    }
}
