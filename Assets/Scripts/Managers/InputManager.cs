using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField]
    private UnitEvent _onUnitSelectedEvent;
    [SerializeField]
    private VoidEvent _onEntityDeselectedEvent;

    private ActionHandler _actionHandler;
    private Unit _selectedUnit;

    InputBaseState _currentState;
    [HideInInspector]
    public InputNoActionState NoActionState = new InputNoActionState();
    [HideInInspector]
    public InputMoveState MoveState = new InputMoveState();
    [HideInInspector]
    public InputAttackState AttackState = new InputAttackState();

    [Header("Debug State Settings")]
    public bool ChangeNoActionState;
    public bool ChangeMoveState;
    public bool ChangeAttackState;

    void Start()
    {
        _actionHandler = new ActionHandler();
        _currentState = NoActionState;
        _currentState.EnterState(this);
    }

    void Update()
    {
        _currentState.UpdateState(this);
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMouseWorlPosition();
            Node node = Grid.Instance.GetNode(mousePosition);
            if (node != null)
            {
                Debug.Log(node.GetInfo());
                Entity entity = node.GetTopEntity();
                if (entity == null)
                {
                    if (_onEntityDeselectedEvent != null)
                        _onEntityDeselectedEvent.Raise();
                }
                else if (entity is Unit)
                {
                    _selectedUnit = (Unit)entity;
                    if (_onUnitSelectedEvent != null)
                        _onUnitSelectedEvent.Raise(_selectedUnit);
                }
                else
                    _selectedUnit = null;

            }
        }
    }

    public void SwitchState(InputBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }

    #region Move Action
    private void SetUpMoveAction()
    {
        IAction moveAction = new MoveAction(_selectedUnit);
        _actionHandler.ActionToHandle = moveAction;
    }

    public void MoveAction()
    {
        if (_selectedUnit == null)
            return;

        SetUpMoveAction();
        _actionHandler.ExecuteCommand();
    }

    public void ShowMobilityArea()
    {
        if (_selectedUnit == null)
            return;

        SetUpMoveAction();
        _actionHandler.ShowInfoCommand();
    }
    #endregion

    private Vector3 GetMouseWorlPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
