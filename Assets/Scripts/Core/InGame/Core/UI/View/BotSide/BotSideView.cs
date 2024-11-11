using Events;
using UnityEngine;
using TMPro;

namespace Core.InGame.UI.Controller
{
    public class BotSideView : EventBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentTurn;
        [SerializeField] private TextMeshProUGUI _leftName;
        [SerializeField] private TextMeshProUGUI _rightName;

        public void Open(string leftName, string rightName)
        {
            _leftName.text = leftName;
            if(!string.IsNullOrEmpty(rightName)) _rightName.text = rightName;
            else _rightName.text = "Существа Уэтмира";
        }

        public void ChangeTurn(int currentTurn)
        {
            _currentTurn.text = currentTurn.ToString();
        }
    }
}