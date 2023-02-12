using UnityEngine;

public class InputAttackState : InputBaseState
{
    public InputAttackState(InputManager context, InputStateFactory factory)
        : base(context, factory) { }

    public override void EnterState()
    {
        Debug.Log("Has entrado en el estado de la acción atacar");
    }

    public override void UpdateState()
    {
        
    }
}
