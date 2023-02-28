using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewResourceType", menuName = "Resource Type")]
public class ResourceTypeSO : ScriptableObject
{
    public ResourceType ResourceType;
    public TileBase ResourceTile;
}
