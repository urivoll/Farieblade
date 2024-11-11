using UnityEngine;

public class RaycastHitChecker2D : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero);

            // ���������, �������� �� ������� � ������ � 2D-�����������
            if (hit.collider != null)
            {
                Debug.Log("Raycast hit: " + hit.collider.name);
            }
            else
            {
                Debug.Log("Raycast did not hit any object.");
            }
        }
    }
}