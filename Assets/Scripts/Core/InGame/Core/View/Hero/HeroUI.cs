using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.InGame.View
{
    public class HeroUI : EventBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textHP;
        [SerializeField] private TextMeshProUGUI _textDmg;
        [SerializeField] private Image _hpBar;
        //[SerializeField] private EnergyUnit _mana;
        [SerializeField] private Gradient _gradient;
        [SerializeField] private Image turnImage;
        [SerializeField] private Sprite[] turnSprites;

        public void Open(int hp, int damage)
        {
            _textHP.text = hp.ToString();
            _textDmg.text = damage.ToString();
        }
        
        public void DoMove()
        {
            turnImage.sprite = turnSprites[0];
        }

        public void RefreshTurnImage()
        {
            turnImage.sprite = turnSprites[1];
        }

        public void SetPosition(Vector2 uiPosition, Transform view)
        {
            transform.SetParent(view);
            transform.localPosition = uiPosition;
        }

        public void ChangeUIData(HeroUI_takeDamageDTO dto)
        {
            _textHP.text = ((int)dto.Hp).ToString();
            _hpBar.fillAmount = dto.HpPercentage / 100;
            _hpBar.color = _gradient.Evaluate(dto.HpPercentage);
        }

        public void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}

public class HeroUI_takeDamageDTO
{
    public float Hp;
    public float HpPercentage;

    public HeroUI_takeDamageDTO(float hp, float hpPercentage)
    {
        Hp = hp;
        HpPercentage = hpPercentage;
    }
}