using System;
using UnityEngine;

namespace _Utils._ToggleButtons {


    public abstract class ToggleGroupAbstract<T> : MonoBehaviour where T : ToggleButtonAbstract {
        [SerializeField] private T[] buttons;
        [SerializeField] private bool canHaveNonSelectedButtons = true;

        public T[] ToggleButtons => buttons;


        public Action<T> OnButtonSelected;
        public Action<T> OnButtonDeselected;

        public void Init(int initialSelectedButtonIndex = -1) {
            for (var i = 0; i < buttons.Length; i++) {
                var b = buttons[i];
                b.Init(i);
                b.onClickedCallback += OnButtonClicked;
                b.onSelected += OnSelectedClicked;
                b.onDeselected += OnDeselectedClicked;
            }

            Setup();

            ResetToDeselectedState();
            if (initialSelectedButtonIndex >= 0 && initialSelectedButtonIndex < buttons.Length) {
                buttons[initialSelectedButtonIndex].Select();
            }
        }

        protected abstract void Setup();

        private void OnButtonClicked(ToggleButtonAbstract b) {
            if (b.isSelected) {
                if (canHaveNonSelectedButtons) {
                    b.Deselect();
                }

                return;
            }

            foreach (var btn in buttons) {
                if (btn.isSelected) {
                    btn.Deselect();
                    break;
                }
            }

            b.Select();
        }

        private void OnSelectedClicked(ToggleButtonAbstract b) {
            OnButtonSelected?.Invoke(b as T);
        }

        private void OnDeselectedClicked(ToggleButtonAbstract b) {
            OnButtonDeselected?.Invoke(b as T);
        }

        public void EnableInteraction(bool enable) {
            foreach (var b in buttons) {
                b.EnableInteraction(enable);
            }
        }

        public void ResetToDeselectedState() {
            foreach (var b in buttons) {
                b.SetToDeselectedState();
            }
        }

        public void SelectButton(int index) {
            buttons[index].Select();
        }
    }
}