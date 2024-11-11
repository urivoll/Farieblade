namespace _Utils._ToggleButtons {
    using _Utils._ToggleButtons;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    namespace UI.UIElement {
        public class ToggleButtonDefaultUI : ToggleButtonAbstract {
            [SerializeField] private Image image;
            [SerializeField] private Sprite selectedState;
            [SerializeField] private Sprite nonSelectedState;
            [SerializeField] private Color selectedTextColor;
            [SerializeField] private Color nonSelectedTextColor;
            [SerializeField] private TextMeshProUGUI text;


            protected override void UpdateSelectedState() {
                image.sprite = selectedState;
                if (text != null) text.color = selectedTextColor;
            }

            protected override void UpdateDeselectedState() {
                image.sprite = nonSelectedState;
                if (text != null) text.color = nonSelectedTextColor;
            }
        }
    }
}