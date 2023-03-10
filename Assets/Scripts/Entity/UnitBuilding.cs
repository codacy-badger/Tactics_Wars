using System.Collections.Generic;
using UnityEngine;

public class UnitBuilding : Building
{
    [Header("Unit Building Settings")]
    [SerializeField]
    private List<EntityInfoSO> _entitiesInfo;

    public List<EntityInfoSO> EntitiesInfo { get { return _entitiesInfo; } }
}
