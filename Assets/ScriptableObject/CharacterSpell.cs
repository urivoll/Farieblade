using UnityEngine;

[CreateAssetMenu(menuName = "SO/Character Spells")]
public class CharacterSpell : ScriptableObject
{
    public string[] Name => _name;
    public MageType Type => _type;
    public string[] Description => _description;
    public Sprite Icon => _icon;
    public string Animation => _animation;
    public AudioClip[] Clips => _clips;

    [SerializeField] private string[] _name;
    [SerializeField] private MageType _type;
    [SerializeField] private string[] _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _animation;
    [SerializeField] private AudioClip[] _clips;
}
