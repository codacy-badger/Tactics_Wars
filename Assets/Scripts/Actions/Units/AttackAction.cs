using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : IAction
{
    public Unit Attacker { get; set; }
    public Unit Attacked { get; set; }

    public AttackAction(Unit attacker, Unit attacked)
    {
        this.Attacker = attacker;
        this.Attacked = attacked;
    }

    public void Execute()
    {
        Debug.Log("Unidad " + Attacker.Name + " ataca a la unidad " + Attacked.Name);
    }

    public void ShowActionInfo()
    {
        Debug.Log("Mostrando informacion AttackAction");
    }
}
