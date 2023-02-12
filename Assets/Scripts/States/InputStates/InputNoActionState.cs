using UnityEngine;

public class InputNoActionState : InputBaseState
{
    public InputNoActionState(InputManager context, InputStateFactory factory)
        : base(context, factory) { }

    public override void EnterState()
    {
        Debug.Log("Entering <color=green>NoAction</color> state");
        Context.SelectedUnit = null;
        Context.OnEntityDeselectedEvent.Raise();
    }

    public override void UpdateState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Context.GetMouseWorldPosition();
            Node node = Grid.Instance.GetNode(mousePosition);
            if (node != null)
            {
                Entity entity = node.GetTopEntity();
                if (entity == null)
                {
                    if (Context.OnEntityDeselectedEvent != null)
                        Context.OnEntityDeselectedEvent.Raise();
                }
                else if (entity is Unit)
                {
                    Context.SelectedUnit = (Unit)entity;
                    if (Context.OnUnitSelectedEvent != null)
                        Context.OnUnitSelectedEvent.Raise(Context.SelectedUnit);
                }
                else
                    Context.SelectedUnit = null;

            }
        }
    }
}
