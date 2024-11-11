using Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.InGame.Utils
{
    public class ClickView : EventBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            DispatchEvent("Удар");
        }
    }
}