using UnityEngine;

public class InputNoActionState : InputBaseState
{
    public override void EnterState(InputManager manager)
    {
        Debug.Log("Has entrado en el estado sin acciones");
    }

    public override void UpdateState(InputManager manager)
    {
        Debug.Log("Update desde el estado sin acciones");
        if (manager.ChangeNoActionState)
            manager.SwitchState(manager.AttackState);
    }
}
