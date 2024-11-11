using UnityEngine;
using UnityEngine.UI;

public class RatingStarsFloat : MonoBehaviour
{
    [SerializeField] private Image _starsImage;
    private int _starsCount = 5;

    public void Rate(float num)
    {
        _starsImage.fillAmount = num / _starsCount;
    }
}
