using UnityEngine;

public class ResourceBuilding : Building
{
    [Header("Resource Building Settings")]
    [SerializeField]
    private ResourceType _resourceType;
    [SerializeField]
    private int _resourceAmount;

    public ResourceType ResourceType { get { return _resourceType; } }
    public int ResourceAmount { get { return _resourceAmount; } }
}

public enum ResourceType
{
    NONE,
    FOOD,
    GOLD
}
