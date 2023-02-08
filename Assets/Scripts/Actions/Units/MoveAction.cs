using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : IAction
{
    public Unit SelectedUnit { get; set; }

    public MoveAction(Unit selectedUnit)
    {
        this.SelectedUnit = selectedUnit;
    }

    public void Execute()
    {
        Debug.Log("Movemos la unidad " + SelectedUnit.Name);
    }

    public void ShowActionInfo()
    {
        Debug.Log("Mostrando informacion MoveAction");
    }
}
