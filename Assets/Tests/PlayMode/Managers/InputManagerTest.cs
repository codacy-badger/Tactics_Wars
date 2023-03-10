using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InputManagerTest
{
    private Unit _unit;
    private EntityInfoSO _entityInfo;

    [SetUp]
    public void SetUp()
    {
        int width = 6;
        int height = 11;
        int cellSize = 1;
        Grid.Instance = new Grid(width, height, cellSize, Vector3.zero);
        Grid.Instance.SetNodesNeighbours();

        _unit = An.Unit.WithPosition(Vector3.zero);
        Grid.Instance.GetNode(_unit.transform.position).AddEntity(_unit);

        UnitBuilding prefab = An.UnitBuilding;
        _entityInfo = An.EntityInfoSO.WithPrefab(prefab.gameObject);
    }

    [UnityTest]
    public IEnumerator Positive_SwitchStates()
    {
        InputManager manager = An.InputManager;
        yield return null;
        Assert.IsTrue(manager.CurrentState is InputNoActionState);

        manager.SetMoveState();
        Assert.IsTrue(manager.CurrentState is InputMoveState);

        manager.SelectedUnit = _unit;
        manager.SetAttackState();
        Assert.IsTrue(manager.CurrentState is InputAttackState);

        manager.SetBuildState(_entityInfo);
        Assert.IsTrue(manager.CurrentState is InputBuildState);

        manager.SetRepairState();
        Assert.IsTrue(manager.CurrentState is InputRepairState);

        manager.FinalizeUnit();
        Assert.IsTrue(_unit.HasFinished);
    }
}
