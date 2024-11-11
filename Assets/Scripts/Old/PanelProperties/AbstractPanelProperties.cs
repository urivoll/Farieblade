using Spine.Unity;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace PanelPropertires
{
    public class AbstractPanelProperties : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI textHPBase;
        [SerializeField] protected TextMeshProUGUI textDmg;
        [SerializeField] protected TextMeshProUGUI textName;
        [SerializeField] protected TextMeshProUGUI textAcc;
        [SerializeField] protected TextMeshProUGUI textInit;
        [SerializeField] protected TextMeshProUGUI textLevel;
        [SerializeField] protected TextMeshProUGUI textGrade;
        [SerializeField] protected TextMeshProUGUI textRang;
        [SerializeField] protected TextMeshProUGUI textFraction;
        [SerializeField] protected TextMeshProUGUI textResist;
        [SerializeField] protected TextMeshProUGUI textDamageType;
        [SerializeField] protected TextMeshProUGUI textVulnerability;
        [SerializeField] protected TextMeshProUGUI textType;

        [SerializeField] protected Image imageBG;
        [SerializeField] protected Image imageRang;
        [SerializeField] protected Image imageType;
        [SerializeField] protected Image imageFraction;
        [SerializeField] protected Image ImgDamageType;
        [SerializeField] protected Image ImgResist;
        [SerializeField] protected Image ImgVulnerability;

        [SerializeField] protected AudioClip _on;
        [SerializeField] protected AudioClip _off;

        [SerializeField] protected GameObject Avat;

        protected GameObject _avatarObject;

        public virtual void SetValue(Unit modelUnit)
        {
            textName.text = modelUnit.transform.Find("Card/shell/Name").gameObject.GetComponent<LanguageText>().text[PlayerData.language];
            textDmg.text = Convert.ToString(modelUnit.damage);
            textHPBase.text = Convert.ToString(modelUnit.hpBase);
            textInit.text = Convert.ToString(modelUnit.initiative);
            textAcc.text = Convert.ToString(modelUnit.accuracy);

            textLevel.text = Convert.ToString(modelUnit.level);
            textGrade.text = Convert.ToString(modelUnit.grade);

            textType.text = modelUnit.characterType.Name[PlayerData.language];
            imageType.sprite = modelUnit.characterType.Icon;

            ImgDamageType.sprite = modelUnit.damageType.Icon;
            textDamageType.text = modelUnit.damageType.Name[PlayerData.language];

            ImgResist.sprite = modelUnit.resist.Icon;
            textResist.text = modelUnit.resist.Name[PlayerData.language];

            ImgVulnerability.sprite = modelUnit.vulnerability.Icon;
            textVulnerability.text = modelUnit.vulnerability.Name[PlayerData.language];

            textRang.text = modelUnit.rang.Name[PlayerData.language];
            imageRang.sprite = modelUnit.rang.Icon;

            imageFraction.sprite = modelUnit.fraction.Icon;
            textFraction.text = modelUnit.fraction.Name[PlayerData.language];

            _avatarObject = Instantiate(modelUnit.modelPanel, Avat.transform);
            _avatarObject.transform.Find("Shade").GetComponent<SpriteRenderer>().sortingLayerName = "TopUI";
            _avatarObject.transform.Find("Shade").GetComponent<SpriteRenderer>().sortingOrder = 3;
            _avatarObject.GetComponent<SkeletonPartsRenderer>().MeshRenderer.sortingLayerName = "TopUI";
            _avatarObject.GetComponent<SkeletonPartsRenderer>().MeshRenderer.sortingOrder = 3;
            _avatarObject.transform.localScale = new Vector2(35, 35);
        }
    }
}