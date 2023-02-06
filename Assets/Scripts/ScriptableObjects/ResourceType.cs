using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewResourceType", menuName = "Resource Type")]
public class ResourceType : ScriptableObject
{
    public string ResourceName;
    public TileBase ResourceTile;
}
