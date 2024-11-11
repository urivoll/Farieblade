using UnityEngine;
using UnityEngine.UI;

public class RatingStarsInt : MonoBehaviour
{
    [SerializeField] private Image[] _starsImage;
    private int _starsCount = 5;

    public void Rate(int num)
    {
        int count = 0;
        for (int i = 0; i < _starsCount; i++)
        {
            _starsImage[i].color = new(1, 1, 1);
            if (i == num - 1)
            {
                count = i + 1;
                break;
            }
        }
        for (int i = count; i < _starsCount; i++)
        {
            _starsImage[i].color = new(0.5f, 0.5f, 0.5f);
        }
    }
}
