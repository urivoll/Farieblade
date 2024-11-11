using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Utils {
    public class InputFieldKeyboardShifter : MonoBehaviour {
        private const string HELPER_GO_NAME = "InputTransformHelper";
        public RectTransform transformToMove;

        private TMP_InputField inputField;
        private Vector2 scrollOriginAnchoredPos;
        private bool prevVisibility;
        private RectTransform rectPositionHelper;
        private RectTransform canvasTr;

#if !UNITY_EDITOR
        private void Start() {
            canvasTr = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            inputField = GetComponent<TMP_InputField>();

            var helperTr = transformToMove.Find(HELPER_GO_NAME);
            if (helperTr == null) rectPositionHelper = new GameObject(HELPER_GO_NAME).AddComponent<RectTransform>();
            else rectPositionHelper = (RectTransform) helperTr;
            rectPositionHelper.SetParent(transformToMove);
        }

        

        private void Update() {
            var hasVisibility = /*TouchScreenKeyboard.visible && */inputField.isFocused;
            if (hasVisibility == prevVisibility) return;

            prevVisibility = hasVisibility;

            if (hasVisibility) {
                rectPositionHelper.SetParent(inputField.transform);
                rectPositionHelper.localPosition = Vector3.zero;
                rectPositionHelper.SetParent(canvasTr.transform);
                var canvasH = canvasTr.rect.size.y;
                var heightP = rectPositionHelper.anchoredPosition.y / canvasH;
                if (heightP < 0) {
                    var deltaP = Mathf.Abs(rectPositionHelper.anchoredPosition.y) / (canvasH / 2);
                    var deltaV = deltaP * canvasH / 2;
                    transformToMove.anchoredPosition = scrollOriginAnchoredPos + Vector2.up * deltaV;
                    print("deltaV: " + deltaV);
                    print("deltaP: " + deltaP);
                }
            } else {
                print("Reset");
                transformToMove.anchoredPosition = scrollOriginAnchoredPos;
                rectPositionHelper.SetParent(canvasTr.transform);
            }
        }
        
#endif
    }
}