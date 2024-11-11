using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Utils._ToggleButtons {
    [RequireComponent(typeof(Image), typeof(Button))]
    public abstract class ToggleButtonAbstract : MonoBehaviour {
        private Button button;

        public Action<ToggleButtonAbstract> onClickedCallback;
        public Action<ToggleButtonAbstract> onSelected;
        public Action<ToggleButtonAbstract> onDeselected;
        public bool isSelected { get; private set; }
        public int index { get; private set; }

        private bool isInitialized;


        public virtual void Init(int index) {
            button = GetComponent<Button>();
            this.index = index;

            button.onClick.AddListener(OnButtonClicked);

            //Deselect();
        }

        public void Select() {
            SetToSelectedState();

            onSelected?.Invoke(this);
        }

        public void Deselect() {
            SetToDeselectedState();

            onDeselected?.Invoke(this);
        }

        protected abstract void UpdateSelectedState();
        protected abstract void UpdateDeselectedState();

        public void SetToDeselectedState() {
            isSelected = false;
            UpdateDeselectedState();
        }

        public void SetToSelectedState() {
            isSelected = true;
            UpdateSelectedState();
        }

        public void EnableInteraction(bool enable) {
            button.interactable = enable;
        }

        /*public void OnPointerDown(PointerEventData eventData) {
            onClickedCallback?.Invoke(this);
        }*/

        private void OnButtonClicked() {
            onClickedCallback?.Invoke(this);
        }
    }
}