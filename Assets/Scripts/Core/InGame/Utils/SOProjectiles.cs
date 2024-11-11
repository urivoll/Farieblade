using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectilesData", menuName = "Game/ProjectilesData")]
public class SOProjectiles : ScriptableObject
{
    public float Speed;
    public GameObject Prefab;
}