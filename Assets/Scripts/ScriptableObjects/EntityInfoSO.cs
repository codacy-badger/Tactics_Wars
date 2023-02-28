using UnityEngine;

[CreateAssetMenu(fileName = "NewEntityInfo", menuName = "Entity Info")]
public class EntityInfoSO : ScriptableObject
{
    public GameObject EntityPrefab;
    public int FoodAmount;
    public int GoldAmount;
}
