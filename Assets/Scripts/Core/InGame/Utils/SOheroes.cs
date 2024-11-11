using UnityEngine;

[CreateAssetMenu(fileName = "NewHeroData", menuName = "Game/HeroData")]
public class SOheroes : ScriptableObject
{
    public int Id;
    public float Hp;
    public float Mana;
    public float Damage;
    public int Times;
    public int Accuarcy;
    public int Initiative;
    public int DamageType;
    public int Vulnerability;
    public int ManaCon;
    public SpellState AttackState;
    public GameObject Prefab;
}