using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class RequiredFields : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _spriteOn;
    [SerializeField] private Sprite _spriteOff;
    [SerializeField] private GameObject _star;
    public bool Done = false;

    public void RedFieldOn()
    {
        if (!Done) return;
        _image.sprite = _spriteOn;
        _star.SetActive(true);
    }

    public void RedFieldOff()
    {
        Done = true;
        _image.sprite = _spriteOff;
        _star.SetActive(false);
    }
}
