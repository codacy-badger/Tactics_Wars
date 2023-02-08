using UnityEngine;

public class InputMoveState : InputBaseState
{
    public override void EnterState(InputManager manager)
    {
        Debug.Log("Has entrado en el estado de la acción mover");
    }

    public override void UpdateState(InputManager manager)
    {
        Debug.Log("Update desde el estado de la acción mover");
        if (manager.ChangeMoveState)
            manager.SwitchState(manager.NoActionState);
    }
}
