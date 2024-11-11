using UnityEngine;

namespace UI.UIElement
{
    public class SafeAreaLayout : MonoBehaviour
    {
        [SerializeField] private bool horizontal = default;
        [SerializeField] private bool vertical = default;
        
        RectTransform Panel;
        private Rect LastSafeArea;
        private float MAX_OFFSET_Y = 65;

        void OnEnable ()
        {
            LastSafeArea = new Rect (0, 0, 0, 0);
            Panel = GetComponent<RectTransform> ();
            Refresh ();
        }
        
#if UNITY_EDITOR
        void Update ()
        {
            Refresh ();
        }
#endif

        void Refresh ()
        {
            Rect safeArea = GetSafeArea ();

            if (safeArea != LastSafeArea)
                ApplySafeArea (safeArea);
        }

        Rect GetSafeArea ()
        {
            var area = Screen.safeArea;
            return area;
        }

        void ApplySafeArea (Rect r)
        {
            LastSafeArea = r;

            // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
            var anchorMin = r.position;
            var anchorMax = r.position + r.size;
            
            if (Screen.height - anchorMax.y > MAX_OFFSET_Y)
                anchorMax.y = Screen.height - MAX_OFFSET_Y;
            
            if (horizontal)
            {
                anchorMin.x /= Screen.width;
                anchorMax.x /= Screen.width;
            }
            else
            {
                anchorMin.x = Panel.anchorMin.x;
                anchorMax.x = Panel.anchorMax.x;
            }

            if (vertical)
            {
                anchorMin.y /= Screen.height;            
                anchorMax.y /= Screen.height;
            }
            else
            {
                anchorMin.y = Panel.anchorMin.y;
                anchorMax.y = Panel.anchorMax.y;
            }

            //only top safe area
            //Panel.anchorMin = anchorMin;
            Panel.anchorMax = anchorMax;
        }
    }
}