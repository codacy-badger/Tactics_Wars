using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : BaseAction
{
    private const float DAMAGE_COEFFICIENT = 0.5f;
    private Unit _attacker;
    private Entity _defender;

    public AttackAction(Unit attacker, Entity defender)
    {
        _attacker = attacker;
        _defender = defender;
    }

    public override void Execute()
    {
        AnimationEventSystem.AnimationFinishedEvent += ApplyDamage;
        _attacker.Animator.SetTrigger("Attack");
    }

    public void ApplyDamage()
    {
        AnimationEventSystem.AnimationFinishedEvent -= ApplyDamage;
        _defender.ApplyDamage(CalculateDamage()); // TODO - aplicar el daño segun tipo de entidad
        if (_defender is Unit)
        {
            Unit defenderUnit = _defender as Unit;
            defenderUnit.Animator.SetTrigger("Hurt");
        }
        Debug.Log($"La unidad {_attacker.Name} ataca a la entidad {_defender.Name}");
        _attacker.HasFinished = true;
        ActionFinished?.Invoke();
    }

    private int CalculateDamage()
    {
        if (_defender is not Unit)
            return _attacker.Damage;
        
        if ((_defender as Unit).Weaknesses.Contains(_attacker.UnitType))
            return Mathf.RoundToInt(_attacker.Damage * (1 + DAMAGE_COEFFICIENT));
        else if (_attacker.Weaknesses.Contains((_defender as Unit).UnitType))
            return Mathf.RoundToInt(_attacker.Damage * DAMAGE_COEFFICIENT);
        else
            return _attacker.Damage;
    }
}
