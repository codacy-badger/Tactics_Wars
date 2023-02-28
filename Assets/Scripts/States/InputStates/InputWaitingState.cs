using UnityEngine;

public class InputWaitingState : InputBaseState
{
    public InputWaitingState(InputManager context, InputStateFactory factory, BaseAction action)
        : base(context, factory)
    {
        NextState = Factory.NoAction();

        action.ActionFinished += SwitchToNextState;
    }

    public override void EnterState()
    {
        Debug.Log("<color=cyan>Waiting</color>: Entering the state");
        Context.SelectedUnit = null;
        Context.OnEntityDeselectedEvent.Raise();
    }

    public override void UpdateState()
    {
        Debug.Log("<color=cyan>Waiting</color> to finish the action");
    }
}
